using System;
namespace EbaloNanol
{
    public class Meeting
    {
        private int indexA;
        private int indexB;
        private int relation;
        private Person partner;

        public Person getPartner() {
            return this.partner;
        }
        public int getIndexA() {
            return indexA;
        }
        public int getRelation() {
            return this.relation;
        }
        public void addRelation(int relation) {
            this.relation += relation;
        }
        public Meeting(int indexA, Person partner, int indexB = 0, int relation = 0) {
            this.indexA = indexA;
            this.partner = partner;
            this.indexB = indexB;
            this.relation = relation;
        }
    }
}
