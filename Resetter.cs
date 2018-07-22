using System;

namespace PhotoAtomic.Sunricher
{
    internal class Resetter : IDisposable
    {
        private Action competion;

        public Resetter(Action completion)
        {
            this.competion = completion;
        }

        public void Dispose()
        {
            competion();
        }
    }
}