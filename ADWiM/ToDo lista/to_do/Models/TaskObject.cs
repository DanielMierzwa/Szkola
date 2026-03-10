using System;
using System.Collections.Generic;
using System.Text;

namespace to_do.Models
{
        public class TaskObject//to jest klasa na jedno zadanie, ma nazwę boola czy jest zrobione
        {
            public string Name { get; set; }
            public bool IsDone { get; set; } = false;
            public string Message { get; private set; } = "Zrobione";// to jest napis który pokazuje się po przeciągnięciu zadania na prawo

            public void Reverse()
            {
                if(IsDone)
                {
                    IsDone = false;
                    Message = "Zrobione";
                }
                else
                {
                    IsDone = true;
                    Message = "Cofnij";
                }
            }
        }
}
