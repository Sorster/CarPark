using System;

namespace Car_park
{
    public class Transport : IComparable, ICloneable
    {
        public Transport() 
        {
            _id = _idCount;
            _idCount++;
        }

        public Transport(CarModel model)
        {
            _id = _idCount;
            _idCount++;
            _model = model;
            SetCarCharacteristics();
        }

        public int _id { get; private set; }

        static int _idCount = 1;

        CarModel _model { get; }
        public string _name { get; private set; }
        public int _maxSpeed { get; private set; }
        public int _weigth { get; private set; }
        public int _numberOfSeats { get; private set; }

        void SetCarCharacteristics()
        {
            switch (_model)
            {
                case CarModel.BMW_X5:
                    {
                        _name = "BMW X5";
                        _maxSpeed = 200;
                        _weigth = 2800;
                        _numberOfSeats = 5;
                        break;
                    }
                case CarModel.Toyota_Corolla:
                    {
                        _name = "Toyota Corolla";
                        _maxSpeed = 300;
                        _weigth = 1500;
                        _numberOfSeats = 5;
                        break;
                    }
                case CarModel.Volkswagen_Beetle:
                    {
                        _name = "Volkswagen Beetle";
                        _maxSpeed = 230;
                        _weigth = 1000;
                        _numberOfSeats = 2;
                        break;
                    }
                case CarModel.Chevrolet_Traverse:
                    {
                        _name = "Chevrolet Traverse";
                        _maxSpeed = 180;
                        _weigth = 3500;
                        _numberOfSeats = 7;
                        break;
                    }
            }

        }
        public void SetId(int id)
        {
            _id = id;
        }
        public void SetIdCount(int count)
        {
            _idCount = count;
        }

        public int CompareTo(object comporationObject)
        {
            Transport car = (Transport)comporationObject;

            bool isEqual = car._model.Equals(_model);
            if (isEqual)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public object Clone()
        {
            return new Transport(_model);
        }
    }
}
