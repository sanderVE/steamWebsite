using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class AchievementModel
    {
        public string name;
        public string description;
        public bool achieved;
        public GameModel game;
    }
}