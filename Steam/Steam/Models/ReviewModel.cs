using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class ReviewModel
    {
        public string inhoud;
        public int beoordeling;
        public bool aanbevolen;
        public DateTime datum;
        public AccountModel reviewedBy;
        public GameModel reviewedGame;
    }
}