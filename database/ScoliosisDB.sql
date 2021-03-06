SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paciente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Paciente](
	[CodigoPaciente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[CPF] [nchar](11) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Endereco] [nvarchar](200) NULL,
	[Complemento] [nvarchar](40) NULL,
	[Bairro] [nvarchar](100) NULL,
	[CEP] [nchar](8) NULL,
	[Cidade] [nvarchar](100) NULL,
	[Estado] [nchar](2) NULL,
	[Sexo] [bit] NOT NULL,
	[Nacionalidade] [nvarchar](50) NULL,
	[Email] [nvarchar](80) NULL,
	[TelefoneResidencial] [nvarchar](30) NULL,
	[TelefoneComercial] [nvarchar](30) NULL,
	[TelefoneCelular] [nvarchar](30) NULL,
	[Observacoes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[CodigoPaciente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Imagem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Imagem](
	[CodigoImagem] [int] IDENTITY(1,1) NOT NULL,
	[TamanhoArquivo] [int] NOT NULL,
	[Arquivo] [image] NOT NULL,
 CONSTRAINT [PK_Imagem] PRIMARY KEY CLUSTERED 
(
	[CodigoImagem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[CodigoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Senha] [nvarchar](80) NOT NULL,
	[Tipo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[CodigoUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND name = N'IX_Login')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Login] ON [dbo].[Usuario] 
(
	[Login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AvaliacaoPostural]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AvaliacaoPostural](
	[CodigoAvaliacaoPostural] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPaciente] [int] NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoImagem] [int] NOT NULL,
	[Angulo1] [float] NOT NULL,
	[Angulo2] [float] NOT NULL,
	[Angulo3] [float] NOT NULL,
	[Angulo4] [float] NOT NULL,
	[Angulo5] [float] NOT NULL,
	[Angulo6] [float] NOT NULL,
	[Angulo7] [float] NOT NULL,
	[Angulo8] [float] NOT NULL,
	[Angulo9] [float] NOT NULL,
	[Angulo10] [float] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Observacoes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_AvaliacaoPostural] PRIMARY KEY CLUSTERED 
(
	[CodigoAvaliacaoPostural] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalculoIMC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CalculoIMC](
	[CodigoCalculoIMC] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPaciente] [int] NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoImagem] [int] NOT NULL,
	[Altura] [float] NOT NULL,
	[Massa] [float] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Observacoes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_CalculoIMC] PRIMARY KEY CLUSTERED 
(
	[CodigoCalculoIMC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ponto]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ponto](
	[CodigoPonto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoImagem] [int] NOT NULL,
	[XImagem] [int] NOT NULL,
	[YImagem] [int] NOT NULL,
	[XCorrigido] [float] NOT NULL,
	[YCorrigido] [float] NOT NULL,
 CONSTRAINT [PK_Ponto] PRIMARY KEY CLUSTERED 
(
	[CodigoPonto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcluirPaciente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-16
-- Description:	Exclui o paciente.
-- =============================================
CREATE PROCEDURE [dbo].[ExcluirPaciente]
	@CodigoPaciente int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o paciente existe
	IF NOT EXISTS(SELECT CodigoPaciente FROM Paciente WHERE CodigoPaciente = @CodigoPaciente)
	BEGIN

		RAISERROR(N''MSG0010'', 16, 1)
		RETURN

	END

	-- inicia transação
	BEGIN TRANSACTION

	-- exclui imagem
	DELETE FROM Imagem
	FROM Imagem INNER JOIN AvaliacaoPostural
	ON Imagem.CodigoImagem = AvaliacaoPostural.CodigoImagem
	WHERE AvaliacaoPostural.CodigoPaciente = @CodigoPaciente

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui imagem
	DELETE FROM Imagem
	FROM Imagem INNER JOIN CalculoIMC
	ON Imagem.CodigoImagem = CalculoIMC.CodigoImagem
	WHERE CalculoIMC.CodigoPaciente = @CodigoPaciente

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui o paciente
	DELETE FROM Paciente
	WHERE CodigoPaciente = @CodigoPaciente

	IF (@@ERROR <> 0)
		Goto ErrorTransaction
	
	COMMIT

	Goto ExitProcedure
ErrorTransaction:
	ROLLBACK
ExitProcedure:
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcluirUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-16
-- Description:	Exclui o usuário.
-- =============================================
CREATE PROCEDURE [dbo].[ExcluirUsuario]
	@CodigoUsuario int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o usuário existe
	IF NOT EXISTS(SELECT CodigoUsuario FROM Usuario WHERE CodigoUsuario = @CodigoUsuario)
	BEGIN

		RAISERROR(N''MSG0003'', 16, 1)
		RETURN

	END

	-- inicia transação
	BEGIN TRANSACTION

	-- exclui o usuário
	DELETE FROM Usuario
	WHERE CodigoUsuario = @CodigoUsuario

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui imagem
	DELETE FROM Imagem
	FROM Imagem LEFT JOIN AvaliacaoPostural
	ON Imagem.CodigoImagem = AvaliacaoPostural.CodigoImagem
	WHERE AvaliacaoPostural.CodigoAvaliacaoPostural IS NULL

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui imagem
	DELETE FROM Imagem
	FROM Imagem LEFT JOIN CalculoIMC
	ON Imagem.CodigoImagem = CalculoIMC.CodigoImagem
	WHERE CalculoIMC.CodigoCalculoIMC IS NULL

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui o paciente
	DELETE FROM Paciente
	FROM Paciente LEFT JOIN AvaliacaoPostural
	ON Paciente.CodigoPaciente = AvaliacaoPostural.CodigoPaciente
	WHERE AvaliacaoPostural.CodigoPaciente IS NULL

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui o paciente
	DELETE FROM Paciente
	FROM Paciente LEFT JOIN CalculoIMC
	ON Paciente.CodigoPaciente = CalculoIMC.CodigoCalculoIMC
	WHERE CalculoIMC.CodigoCalculoIMC IS NULL

	IF (@@ERROR <> 0)
		Goto ErrorTransaction
	
	COMMIT

	Goto ExitProcedure
ErrorTransaction:
	ROLLBACK
ExitProcedure:
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarCalculosIMC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =======================================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-08-03
-- Description:	Lista todos os cálculos de IMC do usuário.
-- =======================================================
CREATE PROCEDURE [dbo].[ListarCalculosIMC]
	@CodigoPaciente int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- lista cálculos
	SELECT CodigoCalculoIMC, CodigoPaciente, CodigoUsuario, CodigoImagem, Altura, Massa, Data, Observacoes
	FROM CalculoIMC
	WHERE CodigoPaciente = @CodigoPaciente
	ORDER BY Data DESC

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscarCalculoIMC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-08-03
-- Description:	Busca pelo cálculo do IMC.
-- =============================================
CREATE PROCEDURE [dbo].[BuscarCalculoIMC]
	@CodigoCalculoIMC int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- busca IMC
	SELECT CodigoCalculoIMC, CodigoPaciente, CodigoUsuario, CodigoImagem, Altura, Massa, Data, Observacoes
	FROM CalculoIMC
	WHERE CodigoCalculoIMC = @CodigoCalculoIMC

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CriarCalculoIMC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-07-29
-- Description:	Cria um cálculo de IMC.
-- =============================================
CREATE PROCEDURE [dbo].[CriarCalculoIMC]
	@CodigoPaciente int,
	@CodigoUsuario int,
	@CodigoImagem int,
	@Altura float,
	@Massa float,
	@Observacoes nvarchar(1000),
	@CodigoCalculoIMC int output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o usuário existe
	IF NOT EXISTS(SELECT CodigoUsuario FROM Usuario WHERE CodigoUsuario = @CodigoUsuario)
	BEGIN

		RAISERROR(N''MSG0003'', 16, 1)
		RETURN

	END

	-- verifica se o paciente existe
	IF NOT EXISTS(SELECT CodigoPaciente FROM Paciente WHERE CodigoPaciente = @CodigoPaciente)
	BEGIN

		RAISERROR(N''MSG0010'', 16, 1)
		RETURN

	END

	-- verifica se a imagem existe
	IF NOT EXISTS(SELECT CodigoImagem FROM Imagem WHERE CodigoImagem = @CodigoImagem)
	BEGIN

		RAISERROR(N''MSG0018'', 16, 1)
		RETURN

	END
		
	-- inicia transação
	BEGIN TRANSACTION
	
	-- cria o cálculo de IMC
	INSERT INTO CalculoIMC(CodigoPaciente, CodigoUsuario, CodigoImagem, Altura, Massa, Data, Observacoes)
	VALUES (@CodigoPaciente, @CodigoUsuario, @CodigoImagem, @Altura, @Massa, Getdate(), @Observacoes)

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
	BEGIN

		SET @CodigoCalculoIMC = @@IDENTITY
		COMMIT

	END

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcluirCalculoIMC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-10-28
-- Description:	Exclui o cálculo do IMC.
-- =============================================
CREATE PROCEDURE [dbo].[ExcluirCalculoIMC]
	@CodigoCalculoIMC int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o cálculo existe
	IF NOT EXISTS(SELECT CodigoCalculoIMC FROM CalculoIMC WHERE CodigoCalculoIMC = @CodigoCalculoIMC)
	BEGIN

		RAISERROR(N''MSG0032'', 16, 1)
		RETURN

	END

	-- inicia transação
	BEGIN TRANSACTION

	-- exclui imagem
	DELETE FROM Imagem
	FROM Imagem INNER JOIN CalculoIMC
	ON Imagem.CodigoImagem = CalculoIMC.CodigoImagem
	WHERE CalculoIMC.CodigoCalculoIMC = @CodigoCalculoIMC

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui a avaliação
	DELETE FROM CalculoIMC
	WHERE CodigoCalculoIMC = @CodigoCalculoIMC

	IF (@@ERROR <> 0)
		Goto ErrorTransaction


	COMMIT

	Goto ExitProcedure
ErrorTransaction:
	ROLLBACK
ExitProcedure:
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarPontosReferencia]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ==============================================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-09-16
-- Description:	Lista os pontos de referência da imagem.
-- ==============================================================
CREATE PROCEDURE [dbo].[ListarPontosReferencia]
	@CodigoImagem int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- lista pontos
	SELECT CodigoPonto, CodigoImagem, XImagem, YImagem, XCorrigido, YCorrigido
	FROM Ponto
	WHERE CodigoImagem = @CodigoImagem
	ORDER BY CodigoPonto

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CriarPonto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-09-27
-- Description:	Cria um ponto de referência.
-- =============================================
CREATE PROCEDURE [dbo].[CriarPonto]
	@CodigoImagem int,
	@XImagem int,
	@YImagem float,
	@XCorrigido float,
	@YCorrigido float
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;
	
	-- inicia transação
	BEGIN TRANSACTION
	
	-- cria o ponto
	INSERT INTO Ponto(CodigoImagem, XImagem, YImagem, XCorrigido, YCorrigido)
	VALUES (@CodigoImagem, @XImagem, @YImagem, @XCorrigido, @YCorrigido)

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
		COMMIT

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarPacientes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-20
-- Description:	Lista todos os usuários.
-- =============================================
CREATE PROCEDURE [dbo].[ListarPacientes]
	@Filtro nvarchar(100)
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	IF (@Filtro <> '''')
	BEGIN

		SELECT CodigoPaciente, Nome, CPF, DataNascimento, Endereco, Complemento,
		Bairro, CEP, Cidade, Estado, Sexo, Nacionalidade, Email, TelefoneResidencial,
		TelefoneComercial, TelefoneCelular, Observacoes
		FROM Paciente
		WHERE Nome LIKE ''%'' + @Filtro + ''%''
		ORDER BY Nome

	END
	ELSE
	BEGIN

		SELECT CodigoPaciente, Nome, CPF, DataNascimento, Endereco, Complemento,
		Bairro, CEP, Cidade, Estado, Sexo, Nacionalidade, Email, TelefoneResidencial,
		TelefoneComercial, TelefoneCelular, Observacoes
		FROM Paciente
		ORDER BY Nome

	END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CriarAvaliacaoPostural]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-09-27
-- Description:	Cria uma avaliação postural.
-- =============================================
CREATE PROCEDURE [dbo].[CriarAvaliacaoPostural]
	@CodigoPaciente int,
	@CodigoUsuario int,
	@CodigoImagem int,
	@Angulo1 float,
	@Angulo2 float,
	@Angulo3 float,
	@Angulo4 float,
	@Angulo5 float,
	@Angulo6 float,
	@Angulo7 float,
	@Angulo8 float,
	@Angulo9 float,
	@Angulo10 float,
	@Observacoes nvarchar(1000),
	@CodigoAvaliacaoPostural int output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o usuário existe
	IF NOT EXISTS(SELECT CodigoUsuario FROM Usuario WHERE CodigoUsuario = @CodigoUsuario)
	BEGIN

		RAISERROR(N''MSG0003'', 16, 1)
		RETURN

	END

	-- verifica se o paciente existe
	IF NOT EXISTS(SELECT CodigoPaciente FROM Paciente WHERE CodigoPaciente = @CodigoPaciente)
	BEGIN

		RAISERROR(N''MSG0010'', 16, 1)
		RETURN

	END

	-- verifica se a imagem existe
	IF NOT EXISTS(SELECT CodigoImagem FROM Imagem WHERE CodigoImagem = @CodigoImagem)
	BEGIN

		RAISERROR(N''MSG0018'', 16, 1)
		RETURN

	END
		
	-- inicia transação
	BEGIN TRANSACTION
	
	-- cria a avaliação postural
	INSERT INTO AvaliacaoPostural(CodigoPaciente, CodigoUsuario, CodigoImagem, Angulo1, Angulo2, Angulo3, Angulo4, 
		Angulo5, Angulo6, Angulo7, Angulo8, Angulo9, Angulo10, Data, Observacoes) VALUES (@CodigoPaciente, @CodigoUsuario, 
		@CodigoImagem, @Angulo1, @Angulo2, @Angulo3, @Angulo4, @Angulo5, @Angulo6, @Angulo7, @Angulo8, @Angulo9, @Angulo10, Getdate(), @Observacoes)

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
	BEGIN

		SET @CodigoAvaliacaoPostural = @@IDENTITY
		COMMIT

	END

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CriarPaciente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-06-16
-- Description:	Cria um novo paciente.
-- =============================================
CREATE PROCEDURE [dbo].[CriarPaciente]
	@Nome nvarchar(200),
	@CPF nchar(11),
	@DataNascimento datetime,
	@Endereco  nvarchar(200),
	@Complemento nvarchar(40),
	@Bairro nvarchar(100),
	@CEP nchar(8),
	@Cidade nvarchar(100),
	@Estado nchar(2),
	@Sexo bit,
	@Nacionalidade nvarchar(50),
	@Email nvarchar(80),
	@TelefoneResidencial nvarchar(30),
	@TelefoneComercial nvarchar(30),
	@TelefoneCelular nvarchar(30),
	@Observacoes nvarchar(1000),
	@CodigoPaciente int output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- inicia transação
	BEGIN TRANSACTION
	
	-- cria o paciente
	INSERT INTO Paciente(Nome, CPF, DataNascimento, Endereco, Complemento, Bairro, CEP, Cidade, Estado, 
	Sexo, Nacionalidade, Email, TelefoneResidencial, TelefoneComercial, TelefoneCelular, Observacoes)
	VALUES (@Nome, @CPF, @DataNascimento, @Endereco, @Complemento, @Bairro, @CEP, @Cidade, @Estado, 
	@Sexo, @Nacionalidade, @Email, @TelefoneResidencial, @TelefoneComercial, @TelefoneCelular, @Observacoes)

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
	BEGIN

		SET @CodigoPaciente = @@IDENTITY
		COMMIT

	END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscarPaciente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-16
-- Description:	Busca pelo paciente.
-- =============================================
CREATE PROCEDURE [dbo].[BuscarPaciente]
	@CodigoPaciente int,
	@Nome nvarchar(200) output,
	@CPF nchar(11) output,
	@DataNascimento datetime output,
	@Endereco  nvarchar(200) output,
	@Complemento nvarchar(40) output,
	@Bairro nvarchar(100) output,
	@CEP nchar(8) output,
	@Cidade nvarchar(100) output,
	@Estado nchar(2) output,
	@Sexo bit output,
	@Nacionalidade nvarchar(50) output,
	@Email nvarchar(80) output,
	@TelefoneResidencial nvarchar(30) output,
	@TelefoneComercial nvarchar(30) output,
	@TelefoneCelular nvarchar(30) output,
	@Observacoes nvarchar(1000) output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o paciente existe
	IF NOT EXISTS(SELECT CodigoPaciente FROM Paciente WHERE CodigoPaciente = @CodigoPaciente)
	BEGIN

		RAISERROR(N''MSG0010'', 16, 1)
		RETURN

	END

	-- busca paciente
	SELECT @Nome = Nome, @CPF = CPF, @DataNascimento = DataNascimento, @Endereco = Endereco,
	@Complemento = Complemento, @Bairro = Bairro, @CEP = CEP, @Cidade = Cidade, 
	@Estado = Estado, @Sexo = Sexo, @Nacionalidade = Nacionalidade, @Email = Email,
	@TelefoneResidencial = TelefoneResidencial, @TelefoneComercial = TelefoneComercial,
	@TelefoneCelular = TelefoneCelular, @Observacoes = Observacoes
	FROM Paciente
	WHERE CodigoPaciente = @CodigoPaciente

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlterarPaciente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-20
-- Description:	Altera os dados do paciente.
-- =============================================
CREATE PROCEDURE [dbo].[AlterarPaciente]
	@CodigoPaciente int,
	@Nome nvarchar(200),
	@CPF nchar(11),
	@DataNascimento datetime,
	@Endereco  nvarchar(200),
	@Complemento nvarchar(40),
	@Bairro nvarchar(100),
	@CEP nchar(8),
	@Cidade nvarchar(100),
	@Estado nchar(2),
	@Sexo bit,
	@Nacionalidade nvarchar(50),
	@Email nvarchar(80),
	@TelefoneResidencial nvarchar(30),
	@TelefoneComercial nvarchar(30),
	@TelefoneCelular nvarchar(30),
	@Observacoes nvarchar(1000)
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o paciente existe
	IF NOT EXISTS(SELECT CodigoPaciente FROM Paciente WHERE CodigoPaciente = @CodigoPaciente)
	BEGIN

		RAISERROR(N''MSG0010'', 16, 1)
		RETURN

	END

	-- inicia transação
	BEGIN TRANSACTION

	-- altera o paciente
	UPDATE Paciente
	SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Endereco = @Endereco, Complemento = @Complemento,
	Bairro = @Bairro, CEP = @CEP, Cidade = @Cidade, Estado = @Estado, Sexo = @Sexo, Nacionalidade = @Nacionalidade, 
	Email = @Email, TelefoneResidencial = @TelefoneResidencial, TelefoneComercial = @TelefoneComercial, 
	TelefoneCelular = @TelefoneCelular, Observacoes = @Observacoes
	WHERE CodigoPaciente = @CodigoPaciente

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
		COMMIT

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarAvaliacoesPosturaisPaciente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ==============================================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-09-16
-- Description:	Lista todas as avaliações posturais do paciente.
-- ==============================================================
CREATE PROCEDURE [dbo].[ListarAvaliacoesPosturaisPaciente]
	@CodigoPaciente int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- lista avaliações
	SELECT CodigoAvaliacaoPostural, CodigoPaciente, CodigoUsuario, CodigoImagem, Angulo1, Angulo2, Angulo3, Angulo4, Angulo5, Angulo6, 
	Angulo7, Angulo8, Angulo9, Angulo10, Data, Observacoes
	FROM AvaliacaoPostural
	WHERE CodigoPaciente = @CodigoPaciente
	ORDER BY Data DESC

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscarAvaliacaoPostural]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-09-16
-- Description:	Busca pela avaliação postural.
-- =============================================
CREATE PROCEDURE [dbo].[BuscarAvaliacaoPostural]
	@CodigoAvaliacaoPostural int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- busca IMC
	SELECT CodigoAvaliacaoPostural, CodigoPaciente, CodigoUsuario, CodigoImagem, Angulo1, Angulo2, Angulo3, Angulo4, Angulo5, Angulo6, 
	Angulo7, Angulo8, Angulo9, Angulo10, Data, Observacoes
	FROM AvaliacaoPostural
	WHERE CodigoAvaliacaoPostural = @CodigoAvaliacaoPostural

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarAvaliacoesPosturais]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ==============================================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-09-16
-- Description:	Lista todas as avaliações posturais.
-- ==============================================================
CREATE PROCEDURE [dbo].[ListarAvaliacoesPosturais]
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- lista avaliações
	SELECT CodigoAvaliacaoPostural, CodigoPaciente, CodigoUsuario, CodigoImagem, Angulo1, Angulo2, Angulo3, Angulo4, Angulo5, Angulo6, 
	Angulo7, Angulo8, Angulo9, Angulo10, Data, Observacoes
	FROM AvaliacaoPostural
	ORDER BY Data ASC

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcluirAvaliacaoPostural]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-10-28
-- Description:	Exclui a avaliação postural.
-- =============================================
CREATE PROCEDURE [dbo].[ExcluirAvaliacaoPostural]
	@CodigoAvaliacaoPostural int
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o a avaliação existe
	IF NOT EXISTS(SELECT CodigoAvaliacaoPostural FROM AvaliacaoPostural WHERE CodigoAvaliacaoPostural = @CodigoAvaliacaoPostural)
	BEGIN

		RAISERROR(N''MSG0033'', 16, 1)
		RETURN

	END

	-- inicia transação
	BEGIN TRANSACTION

	-- exclui imagem
	DELETE FROM Imagem
	FROM Imagem INNER JOIN AvaliacaoPostural
	ON Imagem.CodigoImagem = AvaliacaoPostural.CodigoImagem
	WHERE AvaliacaoPostural.CodigoAvaliacaoPostural = @CodigoAvaliacaoPostural

	IF (@@ERROR <> 0)
		Goto ErrorTransaction

	-- exclui a avaliação
	DELETE FROM AvaliacaoPostural
	WHERE CodigoAvaliacaoPostural = @CodigoAvaliacaoPostural

	IF (@@ERROR <> 0)
		Goto ErrorTransaction


	COMMIT

	Goto ExitProcedure
ErrorTransaction:
	ROLLBACK
ExitProcedure:
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CriarImagem]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-07-29
-- Description:	Cria uma imagem.
-- =============================================
CREATE PROCEDURE [dbo].[CriarImagem]
	@TamanhoArquivo int,
	@Arquivo image,
	@CodigoImagem int output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- inicia transação
	BEGIN TRANSACTION
	
	-- cria a imagem
	INSERT INTO Imagem(TamanhoArquivo, Arquivo) VALUES (@TamanhoArquivo, @Arquivo)

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
	BEGIN

		SET @CodigoImagem = @@IDENTITY
		COMMIT

	END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarUsuarios]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-16
-- Description:	Lista todos os usuários.
-- =============================================
CREATE PROCEDURE [dbo].[ListarUsuarios]
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	SELECT CodigoUsuario, Nome, Login, Senha, Tipo
	FROM Usuario
	ORDER BY Nome

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CriarUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2007-06-11
-- Description:	Cria um novo usuário.
-- =============================================
CREATE PROCEDURE [dbo].[CriarUsuario]
	@Nome nvarchar(200),
	@Login nvarchar(20),
	@Senha nvarchar(80),
	@Tipo tinyint,
	@CodigoUsuario int output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- inicia transação
	BEGIN TRANSACTION
	
	-- cria o usuário
	INSERT INTO Usuario(Nome, Login, Senha, Tipo)
	VALUES (@Nome, @Login, @Senha, @Tipo)

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
	BEGIN

		SET @CodigoUsuario = @@IDENTITY
		COMMIT

	END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscarUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-16
-- Description:	Busca pelo usuário.
-- =============================================
CREATE PROCEDURE [dbo].[BuscarUsuario]
	@CodigoUsuario int,
	@Nome nvarchar(200) output,
	@Login nvarchar(20) output,
	@Senha nvarchar(80) output,
	@Tipo tinyint output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica se o usuário existe
	IF NOT EXISTS(SELECT CodigoUsuario FROM Usuario WHERE CodigoUsuario = @CodigoUsuario)
	BEGIN

		RAISERROR(N''MSG0003'', 16, 1)
		RETURN

	END

	-- busca o usuário
	SELECT @Nome = Nome, @Login = Login, @Senha = Senha, @Tipo = Tipo
	FROM Usuario
	WHERE CodigoUsuario = @CodigoUsuario

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlterarUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-06-16
-- Description:	Altera os dados do usuário.
-- =============================================
CREATE PROCEDURE [dbo].[AlterarUsuario]
	@CodigoUsuario int,
	@Nome nvarchar(200),
	@Login nvarchar(20),
	@Senha nvarchar(80),
	@Tipo tinyint
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- verifica o usuário existe
	IF NOT EXISTS(SELECT CodigoUsuario FROM Usuario WHERE CodigoUsuario = @CodigoUsuario)
	BEGIN

		RAISERROR(N''MSG0003'', 16, 1)
		RETURN

	END

	-- inicia transação
	BEGIN TRANSACTION

	-- altera o usuário
	UPDATE Usuario
	SET Nome = @Nome, Login = @Login, Senha = @Senha, Tipo = @Tipo
	FROM Usuario
	WHERE CodigoUsuario = @CodigoUsuario

	IF (@@ERROR <> 0)
		ROLLBACK
	ELSE
		COMMIT

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =========================================================================================
-- Author:		Ari C. Raimundo
-- Create date: 2003-07-03
-- Description:	Verifica se é possível fazer o login. Se sim, retorna o código do usuário.
-- =========================================================================================
CREATE PROCEDURE [dbo].[Login]
	@Login nvarchar(20),
	@Senha nvarchar(80),
	@CodigoUsuario int output
AS
BEGIN

	-- não conta linhas
	SET NOCOUNT ON;

	-- procura pelo usuário
	IF NOT EXISTS(SELECT CodigoUsuario FROM Usuario WHERE Login = @Login AND Senha = @Senha)
		RETURN 0

	-- busca usuário
	SELECT @CodigoUsuario = CodigoUsuario FROM Usuario WHERE Login = @Login AND Senha = @Senha

	RETURN 1

END
' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AvaliacaoPostural_Imagem]') AND parent_object_id = OBJECT_ID(N'[dbo].[AvaliacaoPostural]'))
ALTER TABLE [dbo].[AvaliacaoPostural]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoPostural_Imagem] FOREIGN KEY([CodigoImagem])
REFERENCES [dbo].[Imagem] ([CodigoImagem])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoPostural] CHECK CONSTRAINT [FK_AvaliacaoPostural_Imagem]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AvaliacaoPostural_Paciente]') AND parent_object_id = OBJECT_ID(N'[dbo].[AvaliacaoPostural]'))
ALTER TABLE [dbo].[AvaliacaoPostural]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoPostural_Paciente] FOREIGN KEY([CodigoPaciente])
REFERENCES [dbo].[Paciente] ([CodigoPaciente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoPostural] CHECK CONSTRAINT [FK_AvaliacaoPostural_Paciente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AvaliacaoPostural_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[AvaliacaoPostural]'))
ALTER TABLE [dbo].[AvaliacaoPostural]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoPostural_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([CodigoUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvaliacaoPostural] CHECK CONSTRAINT [FK_AvaliacaoPostural_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CalculoIMC_Imagem]') AND parent_object_id = OBJECT_ID(N'[dbo].[CalculoIMC]'))
ALTER TABLE [dbo].[CalculoIMC]  WITH CHECK ADD  CONSTRAINT [FK_CalculoIMC_Imagem] FOREIGN KEY([CodigoImagem])
REFERENCES [dbo].[Imagem] ([CodigoImagem])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CalculoIMC] CHECK CONSTRAINT [FK_CalculoIMC_Imagem]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CalculoIMC_Paciente]') AND parent_object_id = OBJECT_ID(N'[dbo].[CalculoIMC]'))
ALTER TABLE [dbo].[CalculoIMC]  WITH CHECK ADD  CONSTRAINT [FK_CalculoIMC_Paciente] FOREIGN KEY([CodigoPaciente])
REFERENCES [dbo].[Paciente] ([CodigoPaciente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CalculoIMC] CHECK CONSTRAINT [FK_CalculoIMC_Paciente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CalculoIMC_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[CalculoIMC]'))
ALTER TABLE [dbo].[CalculoIMC]  WITH CHECK ADD  CONSTRAINT [FK_CalculoIMC_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([CodigoUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CalculoIMC] CHECK CONSTRAINT [FK_CalculoIMC_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ponto_Imagem]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ponto]'))
ALTER TABLE [dbo].[Ponto]  WITH CHECK ADD  CONSTRAINT [FK_Ponto_Imagem] FOREIGN KEY([CodigoImagem])
REFERENCES [dbo].[Imagem] ([CodigoImagem])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ponto] CHECK CONSTRAINT [FK_Ponto_Imagem]
GO
