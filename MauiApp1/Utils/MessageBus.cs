using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepwise.Utils
{
    internal class MessageBus
    {
        private static MessageBus _instance;
        private static readonly object _lock = new();
        private readonly Dictionary<Type, List<Action<object>>> _subscriptions = new();

        public static MessageBus Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MessageBus();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Subscribe<TMessage>(string tag, Action<TMessage> action)
        {
            Type messageType = typeof(TMessage);
            if (!_subscriptions.ContainsKey(messageType))
            {
                _subscriptions[messageType] = new List<Action<object>>();
            }
            _subscriptions[messageType].Add(message =>
            {
                if (message is MessageWithTag<TMessage> messageWithTag && messageWithTag.Tag == tag)
                {
                    action(messageWithTag.Data);
                }
            });
        }

        public void Publish<TMessage>(string tag, TMessage message)
        {
            Type messageType = typeof(TMessage);
            if (_subscriptions.ContainsKey(messageType))
            {
                var messageWithTag = new MessageWithTag<TMessage>(tag, message);
                foreach (var subscription in _subscriptions[messageType])
                {
                    subscription.Invoke(messageWithTag);
                }
            }
        }
    }

    public class MessageWithTag<TMessage>
    {
        public string Tag { get; }
        public TMessage Data { get; }

        public MessageWithTag(string tag, TMessage data)
        {
            Tag = tag;
            Data = data;
        }
    }
}