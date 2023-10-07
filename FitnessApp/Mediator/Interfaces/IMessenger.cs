using FitnessApp.Messages.Interfaces;
using System;

namespace FitnessApp.Mediator.Interfaces;

public interface IMessenger
{
    public interface IMessenger
    {
        void Subscribe<T>(Action<IMessage> action) where T : IMessage;

        void Send<T>(T message) where T : IMessage;
    }
}
