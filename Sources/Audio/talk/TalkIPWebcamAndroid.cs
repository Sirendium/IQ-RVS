﻿using System;
using System.Net.Sockets;
using iSpyApplication.Utilities;
using NAudio.Wave;

namespace iSpyApplication.Sources.Audio.talk
{
    internal class TalkIPWebcamAndroid : ITalkTarget
    {
        private readonly object _obj = new object();
        private bool _bTalking;
        private readonly WaveFormat _waveFormat = new WaveFormat(44100, 16, 1);
        private readonly IAudioSource _audioSource;
        private readonly Uri _server;
        private NetworkStream _avstream;

        public TalkIPWebcamAndroid(Uri server, IAudioSource audioSource)
        {
            _server = server;
            _audioSource = audioSource;
        }

        public void Start()
        {
            try
            {
                var tcp = new TcpClient(_server.Host, _server.Port);
                string hdr = "POST /audioin.alaw HTTP/1.1\r\nHost: " + _server.Host + "\r\nContent-Length: 2147483637\r\n\r\n";
                lock (_obj)
                {
                    _avstream = tcp.GetStream();
                    _avstream.Write(System.Text.Encoding.UTF8.GetBytes(hdr), 0, hdr.Length);
                }

                StartTalk();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex,"Talk (Android)");
                TalkStopped?.Invoke(this, EventArgs.Empty);
            }
        }


        public void Stop()
        {
            StopTalk();
        }

        public bool Connected => (_avstream != null);

        public event TalkStoppedEventHandler TalkStopped;

        private void StartTalk()
        {
            if (_bTalking)
            {
                StopTalk();
            }

            _bTalking = true;
            _bTalking = true;
            _audioSource.DataAvailable += AudioSourceDataAvailable;
        }

        private void StopTalk()
        {
            if (_bTalking)
            {
                lock (_obj)
                {
                    _audioSource.DataAvailable -= AudioSourceDataAvailable;

                    if (_avstream != null)
                    {
                        _avstream.Close();
                        _avstream.Dispose();
                        _avstream = null;
                    }

                    if (_bTalking)
                    {
                        _bTalking = false;
                    }
                    TalkStopped?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void AudioSourceDataAvailable(object sender, DataAvailableEventArgs e)
        {
            try
            {
                lock (_obj)
                {
                    if (_bTalking && _avstream != null)
                    {
                        byte[] bSrc = e.RawData;
                        int totBytes = bSrc.Length;
                        int j = -1;
                        if (!_audioSource.RecordingFormat.Equals(_waveFormat))
                        {
                            var ws = new TalkHelperStream(bSrc, totBytes, _audioSource.RecordingFormat);
                            
                            var bDst = new byte[44100];
                            totBytes = 0;
                            using (var helpStm = new WaveFormatConversionStream(_waveFormat, ws))
                            {
                                while (j != 0)
                                {
                                    j = helpStm.Read(bDst, totBytes, 10000);
                                    totBytes += j;
                                }
                            }
                            bSrc = bDst;
                            
                        }
                        var enc = new byte[totBytes / 2];
                        ALawEncoder.ALawEncode(bSrc, totBytes, enc);


                        try
                        {
                            _avstream.Write(enc, 0, enc.Length);
                        }
                        catch (SocketException)
                        {
                            StopTalk();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex,"Talk (Android)");
                StopTalk();
            }
        }
    }
}