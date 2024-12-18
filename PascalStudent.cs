namespace MarksAndStudent
{
    public enum Result
    {
        ADMITTED,
        NOTADMITTED,
        SUSPENDED
    }
    public class PascalStudent
    {
        private int[] _marks;
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public PascalStudent(bool isBiennium, string name, string surname)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentNullException("surname");

            if (isBiennium)
                _marks = new int[13];
            else
                _marks = new int[10];

            Name = name;
            Surname = surname;
        }

        public void addMark(int mark)
        {
            if (mark <= 0 || mark > 10) throw new ArgumentOutOfRangeException("Mark not valid");

            bool insert = false;
            int count = 0;

            while (!insert)
            {
                if (_marks[count] == 0)
                {
                    _marks[count] = mark;
                    insert = true;
                }
                count++;
            }
        }

        public double avarage()
        {
            int sum = 0;
            foreach (int mark in _marks)
            {
                sum += mark;
            }
            return (double)sum / _marks.Length;
        }

        public int numberOfInsufficiencies()
        {
            int count = 0;
            foreach (int mark in _marks)
            {
                if (mark < 6)
                {
                    count++;
                }
            }
            return count;
        }

        public int pointToSufficiency()
        {
            int count = 0;
            foreach (int mark in _marks)
            {
                if (mark < 6)
                {
                    count += (6 - mark);
                }
            }
            return count;
        }

        public Result scrutiny()
        {
            // point in insufficiencies < 4 suspended, like if you have a 4 and a 5 you are suspended
            // point in insufficiencies > 3 not admitted, so if you have a 3 and a 5 you are not admitted
            if (pointToSufficiency() <= 3)
                return Result.SUSPENDED;
            else if (pointToSufficiency() > 3)
                return Result.NOTADMITTED;
            else
                return Result.ADMITTED;

        }
    }
}
