using System;

namespace UtilitiesMain.DataClasses
{
    public class Publisher
    {

        //public string name;
        //public int since;
        //public long ico;

        private string name;
        private int since;
        private long ico;

        public Publisher(string name, int since, long ico)
        {
            this.name = name;
            this.since = since;
            this.ico = ico;
        }

        public string Name
        {
            get { return this.name; }
        }
        public int Since
        {
            get { return this.since; }
        }
        public long Ico
        {
            get { return this.ico; }
        }

        //public string GetName()
        //{
        //    return this.name;
        //}
        //public int GetSince()
        //{
        //    return this.since;
        //}
        //public long GetIco()
        //{
        //    return this.ico;
        //}

    }
}
