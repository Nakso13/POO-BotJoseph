using System;
using System.Collections.Generic;

namespace Jeu_du_421
{
    public class Game
    {
        public int NbManches { get; private set; }
        public int NbDes { get; private set; }
        public int NbDesTruques { get; private set; }

        public List<De> listeDes = new List<De>();

        public Game()
        {
            NbManches = 5;
            NbDes = 5;
        }

        public Game(int NbManches, int NbDes)
        {
            this.NbManches = NbManches;
            this.NbDes = NbDes;
        }

        public Game(int NbManches, int NbDes, int NbDesTruques)
        {
            this.NbManches = NbManches;
            this.NbDes = NbDes;
            this.NbDesTruques = NbDesTruques;
        }

        public void Relancer(int position)
        {
            listeDes[position - 1].Lancer();
        }

        public int Score()
        {
            int score = 0;
            foreach (De de in listeDes) {
                score += de.Face;
            }
            return score;
        }

        public void Run()
        {
            for (int i = 0; i < NbDes; i++) {
                De de = new De();
                listeDes.Add(de);
            }

            for (int i = 0; i < NbDesTruques; i++) {
                DeTruque de = new DeTruque();
                listeDes.Add(de);
            }

            for (int i = 0; i < listeDes.Count; i++) {
                Relancer(i+1);
            }

            int NbTours = NbManches;
            while (NbTours > 0) {
                AfficheDe();
                Console.Write("Choissisez la position du dé que vous voulez relancer : ");
                string relance = Console.ReadLine();
                string[] relanceDe = relance.Split(",");
                foreach (string De in relanceDe)
                    Relancer(int.Parse(De));
                NbTours -= 1;
            }

            AfficheDe();
            Console.WriteLine($"Vous avez fait {Score()} points !");
        }

        public void AfficheDe()
        {
            foreach (De de in listeDes) {
                Console.Write("+---+ ");
            }
            Console.WriteLine();
            foreach (De de in listeDes) {
                Console.Write("| {0} | ", de.Face);
            }
            Console.WriteLine();
            foreach (De de in listeDes) {
                Console.Write("+---+ ");
            }
            Console.WriteLine();
        }
    }
}
