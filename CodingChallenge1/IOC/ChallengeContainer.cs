using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge1.IOC
{
    public class ChallengeContainer : Container
    {
        private static ChallengeContainer _challengeContainer;

        private ChallengeContainer()
        {
        }

        public static ChallengeContainer getChallengeContainer()
        {
            if (_challengeContainer == null)
            {
                _challengeContainer = new ChallengeContainer();
            }

            return _challengeContainer;
        }
    }
}