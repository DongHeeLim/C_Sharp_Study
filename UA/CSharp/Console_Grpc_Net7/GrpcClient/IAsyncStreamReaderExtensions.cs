using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcClient
{
    public static class IAsyncStreamReaderExtensions
    {
        public static IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IAsyncStreamReader<T> asyncStreamReader)
        {
            if (asyncStreamReader == null) { throw new ArgumentNullException(nameof(asyncStreamReader)); }

            return new ToAsyncEnumerableEnumerable<T>(asyncStreamReader);
        }

        private sealed class ToAsyncEnumerableEnumerable<Tout> : IAsyncEnumerable<Tout>
        {
            public IAsyncEnumerator<Tout> GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new ToAsyncEnumeratorEnumerator<Tout>(_asyncStreamReader, cancellationToken);

            private readonly IAsyncStreamReader<Tout> _asyncStreamReader;

            public ToAsyncEnumerableEnumerable(IAsyncStreamReader<Tout> asyncStreamReader)
            {
                _asyncStreamReader = asyncStreamReader;
            }

            private sealed class ToAsyncEnumeratorEnumerator<T> : IAsyncEnumerator<T>
            {
                public T Current => _asyncStreamReader.Current;

                public async ValueTask<bool> MoveNextAsync() => await _asyncStreamReader.MoveNext(_cancellationToken);

                public ValueTask DisposeAsync() => default;

                private readonly IAsyncStreamReader<T> _asyncStreamReader;
                private readonly CancellationToken _cancellationToken;

                public ToAsyncEnumeratorEnumerator(IAsyncStreamReader<T> asyncStreamReader, CancellationToken cancellationToken)
                {
                    _asyncStreamReader = asyncStreamReader;
                    _cancellationToken = cancellationToken;
                }
            }
        }

    }
}
