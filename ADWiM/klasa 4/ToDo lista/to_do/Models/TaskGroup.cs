using System;
using System.Collections.Generic;
using System.Text;

namespace to_do.Models
{
    public class TaskGroup : List<TaskObject>// to jest klasa na kategorię zadań, ma ona nazwę i listę zadań TaskObjects,
                                             // tak naprawdę to trochę zmieniona lista typu TaskObject
    {
        public string GroupName { get; private set; }
        public TaskGroup(string groupName, List<TaskObject> tasks)
            //konstruktor, daje sie mu nazwę grupy i na początku ma pustą listę
            :base(tasks)//wywołuje konstruktor klasy bazowej czyli List<TaskObject>, żeby zainicjalizować tę listę)
        {
            GroupName = groupName;
        }
    }
}
