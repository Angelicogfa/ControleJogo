using System;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class ImagemJogo : IDisposable
    {
        public byte[] FotoJogo  { get; private set; }

        public ImagemJogo(byte[] FotoJogo)
        {

        }

        protected ImagemJogo()
        {

        }

        public void Dispose()
        {
            FotoJogo = null;
        }
    }
}
