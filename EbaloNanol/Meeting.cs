using System;
// <copyright file="Meeting.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Sorokin Dmitrii</author>
// <date>08/30/2018 12:10:53 AM </date>
// <summary>Meeting class. Keeps information about partners and relation</summary>
namespace Life
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
