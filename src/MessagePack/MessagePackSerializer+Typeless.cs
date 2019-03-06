﻿#if !UNITY

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MessagePack
{
    public partial class MessagePackSerializer
    {
        /// <summary>
        /// A convenience wrapper around <see cref="MessagePackSerializer"/> that assumes all generic type arguments are <see cref="object"/>.
        /// </summary>
        public class Typeless
        {
            private readonly MessagePackSerializer serializer;

            public Typeless()
                : this(new MessagePackSerializer(new Resolvers.TypelessContractlessStandardResolver()))
            {
            }

            public Typeless(MessagePackSerializer serializer)
            {
                this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            }

            public byte[] Serialize(object obj) => serializer.Serialize(obj);

            public void Serialize(Stream stream, object obj) => serializer.Serialize(stream, obj);

            public ValueTask SerializeAsync(Stream stream, object obj, CancellationToken cancellationToken) => serializer.SerializeAsync(stream, obj, cancellationToken: cancellationToken);

            public object Deserialize(byte[] bytes) => serializer.Deserialize<object>(bytes);

            public object Deserialize(Stream stream) => serializer.Deserialize<object>(stream);

            public object Deserialize(ArraySegment<byte> bytes) => serializer.Deserialize<object>(bytes);

            public ValueTask<object> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default) => serializer.DeserializeAsync<object>(stream, cancellationToken: cancellationToken);
        }
    }
}

#endif