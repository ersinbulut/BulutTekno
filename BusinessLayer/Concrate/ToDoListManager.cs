using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public ToDoList GetByID(int id)
        {
            return _toDoListDal.Get(x => x.ToDoID == id);
        }

        public List<ToDoList> GetList()
        {
            return _toDoListDal.List();
        }

        public void ToDoListAdd(ToDoList toDoList)
        {
            _toDoListDal.Insert(toDoList);
        }

        public void ToDoListDelete(ToDoList toDoList)
        {
            _toDoListDal.Delete(toDoList);
        }

        public void ToDoListUpdate(ToDoList toDoList)
        {
            _toDoListDal.Update(toDoList);
        }
    }
}
