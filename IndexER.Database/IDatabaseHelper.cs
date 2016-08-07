using System;

namespace IndexER.Database
{
    public interface IDatabaseHelper
    {
        string GetConnectionString();
        void Execute(Action action);
    }
}
