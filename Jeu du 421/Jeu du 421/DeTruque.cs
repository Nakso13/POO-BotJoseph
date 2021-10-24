using System;

namespace Jeu_du_421
{
    public class DeTruque : De
    {
        private Random random = new Random();

        public override int Lancer()
        {
            int rng;
            rng = random.Next(1, 13);
            if (rng == 1)
            {
                return Face = random.Next(1, 5);
            }
            else if (rng == 2 || rng == 3)
            {
                return Face = 5;
            }
            else
            {
                return Face = 6;
            }
        }
    }
}
