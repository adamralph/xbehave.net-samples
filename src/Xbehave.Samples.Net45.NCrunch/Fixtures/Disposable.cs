namespace Xbehave.Samples.Fixtures
{
    using System;
#if NETFX_CORE || WPA81
    using System.Diagnostics;
#endif

    public sealed class Disposable : IDisposable
    {
        private readonly string id = Guid.NewGuid().ToString();

        public Disposable()
        {
#if NETFX_CORE || WPA81
            Debug
#else
            Console
#endif
                .WriteLine("CREATED: {0}", this.id);
        }

        public void Use()
        {
#if NETFX_CORE || WPA81
            Debug
#else
            Console
#endif
                .WriteLine("USED: {0}", this.id);
        }

        public void Dispose()
        {
#if NETFX_CORE || WPA81
            Debug
#else
            Console
#endif
                .WriteLine("DISPOSED: {0}", this.id);
        }
    }
}
