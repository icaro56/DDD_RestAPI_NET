using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Domain.Notifications
{
    public class Notify
    {
        public Notify()
        {
            Notifications = new List<Notify>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notify> Notifications;

        public bool ValidatePropertyString(string value, string nameProperty)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    PropertyName = nameProperty
                });

                return false;
            }

            return true;
        }

        public bool ValidatePropertyInt(int value, string nameProperty)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    PropertyName = nameProperty
                });

                return false;
            }

            return true;
        }

        public bool ValidatePropertyDecimal(decimal value, string nameProperty)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    PropertyName = nameProperty
                });

                return false;
            }

            return true;
        }
    }
}
