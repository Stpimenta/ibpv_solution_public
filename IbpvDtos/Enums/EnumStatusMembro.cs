using System.ComponentModel;

namespace IbpvDtos.Enums;

public enum EnumStatusMembro
{
    [Description ("desativado")] 
    desativado = 0,
    
    [Description ("ativo")] 
    ativo = 1, 
        
    [Description ("aguarda aprove")] 
    preCadastro = 2,
        
    [Description ("ausente")] 
    ausente = 3,
    
  
}

