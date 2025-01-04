using System.ComponentModel;

namespace IbpvDtos.Enums;

public enum EnumRule
{
    [Description ("root")] 
    root = 0, 
    [Description ("admin")] 
    admin = 1,  
    [Description ("tesouraria")]  
    tesouraria = 2,  
    [Description ("membro")]  
    membro = 3,
    [Description ("pending")]  
    pending = 4,
}