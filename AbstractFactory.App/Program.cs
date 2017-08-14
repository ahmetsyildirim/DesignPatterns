using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.App
{
    class Program
    {
        static void Main(string[] args)
        {
            SonyEncoder sony = new SonyEncoder();
            EncodingClient client = new EncodingClient(sony);
            client.EncodeVideo();

            AppleEncoder apple = new AppleEncoder();
            EncodingClient client2 = new EncodingClient(apple);
            client2.EncodeVideo();

            Console.Read();
        }
    }

    /// <summary>
    /// Abstract Factory
    /// </summary>
    abstract class MediaEncoderFactory
    {
        public abstract AudioEncoder CreateAudioEncoder();
        public abstract VideoEncoder CreateVideoEncoder();

    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    class SonyEncoder : MediaEncoderFactory
    {
        public override AudioEncoder CreateAudioEncoder()
        {
            return new MP3Encoder();
        }

        public override VideoEncoder CreateVideoEncoder()
        {
            return new AVIEncoder();
        }
    }

    /// <summary>
    /// Another concrete factory
    /// </summary>
    class AppleEncoder : MediaEncoderFactory
    {
        public override AudioEncoder CreateAudioEncoder()
        {
            return new FLACEncoder();
        }

        public override VideoEncoder CreateVideoEncoder()
        {
            return new QuickTimeEncoder();
        }
    }

    /// <summary>
    /// Abstract Product1
    /// </summary>
    abstract class AudioEncoder
    {

    }

    /// <summary>
    /// Abstract Product2
    /// </summary>
    abstract class VideoEncoder
    {
        public abstract void Encode();
    }

    /// <summary>
    /// Concrete product1
    /// </summary>
    class MP3Encoder : AudioEncoder
    {
    }

    /// <summary>
    /// Concrete product2
    /// </summary>
    class FLACEncoder : AudioEncoder
    {

    }

    /// <summary>
    /// Concrete product3
    /// </summary>
    class AVIEncoder : VideoEncoder
    {
        public override void Encode()
        {
            Console.WriteLine("AVI video encoding completed");
        }
    }

    /// <summary>
    /// Concrete product 4
    /// </summary>
    class QuickTimeEncoder : VideoEncoder
    {
        public override void Encode()
        {
            Console.WriteLine("Quicktime video encoding completed");
        }
    }

    /// <summary>
    /// Client
    /// </summary>
    class EncodingClient
    {
        private AudioEncoder _audioEncoder;
        private VideoEncoder _videoEncoder;

        public EncodingClient(MediaEncoderFactory factory )
        {
            _audioEncoder = factory.CreateAudioEncoder();

            _videoEncoder = factory.CreateVideoEncoder();
        }

        public void EncodeVideo()
        {
            _videoEncoder.Encode();
        }
    }


}
