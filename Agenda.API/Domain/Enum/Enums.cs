using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.API.Domain.Enum
{
    public enum EnumCor
    {
        BRANCO = 1,
        PARDO = 2,
        PRETO = 3,
        INDIGENA = 4,
        AMARELO = 5,
        OUTRO = 6
    }

    public enum EnumRegimeCivil
    {
    }

    public enum EnumEstadoCivil
    {
        CASADO = 1,
        DIVORCIADO = 2,
        SOLTEIRO = 3,
        VIUVO = 4,
        SEPARADO_JUDICIALMENTE = 5
    }

    public enum EnumSexo
    {
        FEMININO = 1,
        MASCULINO = 2,
        OUTRO = 3

    }

    public enum EnumSituacao
    {
       PENDENTE =1,
       AGENDADO =2,
       ENCERRADO = 3,
       CANCELADO =9

    }

    public enum EnumTipoPermissao { 
        LEITURA = 1,
        ESCRITA =2,
        LEITURA_ESCRITA = 3
    }
}
