using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace c___Api_Example.Enums
{
    public enum EnumStatustarefa
    {
        [Description ("A fazer")] 
        Afazer = 1,  
        [Description ("Em andamento")]  
        EmAndamento = 2,  
        [Description ("Concluido")]  
        Concluido = 3,
    }
}