using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class RasporedDirector
    {
        private IRasporedBuilder builder;

        public IRasporedBuilder Builder
        {
            set { builder = value; }
        }

        public void buildRaspored()
        {
            this.builder.BuildEmisije();
            this.builder.BuildProgrami();
        }
    }
}
