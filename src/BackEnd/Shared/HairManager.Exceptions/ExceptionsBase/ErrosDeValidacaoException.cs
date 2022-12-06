﻿namespace HairManager.Exceptions.ExceptionsBase;

public class ErrosDeValidacaoException : HairManagerException
{
    public List<string> MensagensDeErro { get; set; }

	public ErrosDeValidacaoException(List<string> mensagensDeErro)
	{
		MensagensDeErro = mensagensDeErro;
	}
}
