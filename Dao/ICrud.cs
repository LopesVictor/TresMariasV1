using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    interface ICrud<T>
    {
        List<T> Search(string term);
        List<T> List();
        T Get(int Id);
        void Delete(int Id);
        void Update(T ent);
        int Insert(T ent);

    }
}
