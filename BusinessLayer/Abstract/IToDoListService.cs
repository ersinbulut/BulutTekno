using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IToDoListService
    {
        List<ToDoList> GetList();

        void ToDoListAdd(ToDoList toDoList);
        //id ye göre işlem yapıcak
        ToDoList GetByID(int id);
        void ToDoListDelete(ToDoList toDoList);
        void ToDoListUpdate(ToDoList toDoList);
    }
}
