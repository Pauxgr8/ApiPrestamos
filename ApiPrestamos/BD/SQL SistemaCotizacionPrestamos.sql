CREATE DATABASE SistemaCotizacionPrestamos;
GO
--Paula Kevin Roberth
USE SistemaCotizacionPrestamos;
GO

/*=========================================================
    TABLA: Rol
=========================================================*/
CREATE TABLE Rol
(
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarRol
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Rol (Nombre, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Nombre, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdRol;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerRoles
AS
BEGIN
    SELECT IdRol, Nombre, Descripcion, Activo, FechaCreacion, UsuarioCreacion, 
           FechaModificacion, UsuarioModificacion
    FROM Rol
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerRolPorId
    @IdRol INT
AS
BEGIN
    SELECT IdRol, Nombre, Descripcion, Activo, FechaCreacion, UsuarioCreacion, 
           FechaModificacion, UsuarioModificacion
    FROM Rol
    WHERE IdRol = @IdRol;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarRol
    @IdRol INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Rol
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRol = @IdRol;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarRol
    @IdRol INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Rol
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRol = @IdRol;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Genero
=========================================================*/
CREATE TABLE Genero
(
    IdGenero INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(30) NOT NULL,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarGenero
    @Nombre VARCHAR(30),
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Genero (Nombre, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Nombre, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdGenero;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerGeneros
AS
BEGIN
    SELECT IdGenero, Nombre, Activo, FechaCreacion, UsuarioCreacion, 
           FechaModificacion, UsuarioModificacion
    FROM Genero
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerGeneroPorId
    @IdGenero INT
AS
BEGIN
    SELECT IdGenero, Nombre, Activo, FechaCreacion, UsuarioCreacion, 
           FechaModificacion, UsuarioModificacion
    FROM Genero
    WHERE IdGenero = @IdGenero;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarGenero
    @IdGenero INT,
    @Nombre VARCHAR(30),
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Genero
    SET Nombre = @Nombre,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdGenero = @IdGenero;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarGenero
    @IdGenero INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Genero
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdGenero = @IdGenero;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: NivelEducativo
=========================================================*/
CREATE TABLE NivelEducativo
(
    IdNivelEducativo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarNivelEducativo
    @Nombre VARCHAR(50),
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO NivelEducativo (Nombre, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Nombre, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdNivelEducativo;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerNivelesEducativos
AS
BEGIN
    SELECT IdNivelEducativo, Nombre, Activo, FechaCreacion, UsuarioCreacion, 
           FechaModificacion, UsuarioModificacion
    FROM NivelEducativo
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerNivelEducativoPorId
    @IdNivelEducativo INT
AS
BEGIN
    SELECT IdNivelEducativo, Nombre, Activo, FechaCreacion, UsuarioCreacion, 
           FechaModificacion, UsuarioModificacion
    FROM NivelEducativo
    WHERE IdNivelEducativo = @IdNivelEducativo;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarNivelEducativo
    @IdNivelEducativo INT,
    @Nombre VARCHAR(50),
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE NivelEducativo
    SET Nombre = @Nombre,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdNivelEducativo = @IdNivelEducativo;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarNivelEducativo
    @IdNivelEducativo INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE NivelEducativo
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdNivelEducativo = @IdNivelEducativo;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: RangoEdad
=========================================================*/
CREATE TABLE RangoEdad
(
    IdRangoEdad INT IDENTITY(1,1) PRIMARY KEY,
    EdadMinima INT NOT NULL,
    EdadMaxima INT NOT NULL,
    Descripcion VARCHAR(50),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarRangoEdad
    @EdadMinima INT,
    @EdadMaxima INT,
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO RangoEdad (EdadMinima, EdadMaxima, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@EdadMinima, @EdadMaxima, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdRangoEdad;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerRangosEdad
AS
BEGIN
    SELECT IdRangoEdad, EdadMinima, EdadMaxima, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM RangoEdad
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerRangoEdadPorId
    @IdRangoEdad INT
AS
BEGIN
    SELECT IdRangoEdad, EdadMinima, EdadMaxima, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM RangoEdad
    WHERE IdRangoEdad = @IdRangoEdad;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarRangoEdad
    @IdRangoEdad INT,
    @EdadMinima INT,
    @EdadMaxima INT,
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE RangoEdad
    SET EdadMinima = @EdadMinima,
        EdadMaxima = @EdadMaxima,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRangoEdad = @IdRangoEdad;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarRangoEdad
    @IdRangoEdad INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE RangoEdad
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRangoEdad = @IdRangoEdad;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: RangoIngresos
=========================================================*/
CREATE TABLE RangoIngresos
(
    IdRangoIngresos INT IDENTITY(1,1) PRIMARY KEY,
    IngresoMinimo DECIMAL(10,2) NOT NULL,
    IngresoMaximo DECIMAL(10,2) NOT NULL,
    Descripcion VARCHAR(50),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarRangoIngresos
    @IngresoMinimo DECIMAL(10,2),
    @IngresoMaximo DECIMAL(10,2),
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO RangoIngresos (IngresoMinimo, IngresoMaximo, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@IngresoMinimo, @IngresoMaximo, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdRangoIngresos;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerRangosIngresos
AS
BEGIN
    SELECT IdRangoIngresos, IngresoMinimo, IngresoMaximo, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM RangoIngresos
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerRangoIngresosPorId
    @IdRangoIngresos INT
AS
BEGIN
    SELECT IdRangoIngresos, IngresoMinimo, IngresoMaximo, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM RangoIngresos
    WHERE IdRangoIngresos = @IdRangoIngresos;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarRangoIngresos
    @IdRangoIngresos INT,
    @IngresoMinimo DECIMAL(10,2),
    @IngresoMaximo DECIMAL(10,2),
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE RangoIngresos
    SET IngresoMinimo = @IngresoMinimo,
        IngresoMaximo = @IngresoMaximo,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRangoIngresos = @IdRangoIngresos;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarRangoIngresos
    @IdRangoIngresos INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE RangoIngresos
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRangoIngresos = @IdRangoIngresos;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: TipoPrestamo
=========================================================*/
CREATE TABLE TipoPrestamo
(
    IdTipoPrestamo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarTipoPrestamo
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO TipoPrestamo (Nombre, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Nombre, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdTipoPrestamo;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerTiposPrestamo
AS
BEGIN
    SELECT IdTipoPrestamo, Nombre, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM TipoPrestamo
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerTipoPrestamoPorId
    @IdTipoPrestamo INT
AS
BEGIN
    SELECT IdTipoPrestamo, Nombre, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM TipoPrestamo
    WHERE IdTipoPrestamo = @IdTipoPrestamo;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarTipoPrestamo
    @IdTipoPrestamo INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE TipoPrestamo
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdTipoPrestamo = @IdTipoPrestamo;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarTipoPrestamo
    @IdTipoPrestamo INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE TipoPrestamo
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdTipoPrestamo = @IdTipoPrestamo;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Plazo
=========================================================*/
CREATE TABLE Plazo
(
    IdPlazo INT IDENTITY(1,1) PRIMARY KEY,
    Meses INT NOT NULL,
    Descripcion VARCHAR(50),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarPlazo
    @Meses INT,
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Plazo (Meses, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Meses, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdPlazo;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerPlazos
AS
BEGIN
    SELECT IdPlazo, Meses, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM Plazo
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerPlazoPorId
    @IdPlazo INT
AS
BEGIN
    SELECT IdPlazo, Meses, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM Plazo
    WHERE IdPlazo = @IdPlazo;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarPlazo
    @IdPlazo INT,
    @Meses INT,
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Plazo
    SET Meses = @Meses,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdPlazo = @IdPlazo;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarPlazo
    @IdPlazo INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Plazo
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdPlazo = @IdPlazo;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: TasaInteres
=========================================================*/
CREATE TABLE TasaInteres
(
    IdTasaInteres INT IDENTITY(1,1) PRIMARY KEY,
    TasaMinima DECIMAL(5,2) NOT NULL,
    TasaMaxima DECIMAL(5,2) NOT NULL,
    Descripcion VARCHAR(50),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarTasaInteres
    @TasaMinima DECIMAL(5,2),
    @TasaMaxima DECIMAL(5,2),
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO TasaInteres (TasaMinima, TasaMaxima, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@TasaMinima, @TasaMaxima, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdTasaInteres;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerTasasInteres
AS
BEGIN
    SELECT IdTasaInteres, TasaMinima, TasaMaxima, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM TasaInteres
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerTasaInteresPorId
    @IdTasaInteres INT
AS
BEGIN
    SELECT IdTasaInteres, TasaMinima, TasaMaxima, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM TasaInteres
    WHERE IdTasaInteres = @IdTasaInteres;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarTasaInteres
    @IdTasaInteres INT,
    @TasaMinima DECIMAL(5,2),
    @TasaMaxima DECIMAL(5,2),
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE TasaInteres
    SET TasaMinima = @TasaMinima,
        TasaMaxima = @TasaMaxima,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdTasaInteres = @IdTasaInteres;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarTasaInteres
    @IdTasaInteres INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE TasaInteres
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdTasaInteres = @IdTasaInteres;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: CapacidadPago
=========================================================*/
CREATE TABLE CapacidadPago
(
    IdCapacidadPago INT IDENTITY(1,1) PRIMARY KEY,
    PagoMinimo DECIMAL(10,2) NOT NULL,
    PagoMaximo DECIMAL(10,2) NOT NULL,
    Descripcion VARCHAR(50),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarCapacidadPago
    @PagoMinimo DECIMAL(10,2),
    @PagoMaximo DECIMAL(10,2),
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO CapacidadPago (PagoMinimo, PagoMaximo, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@PagoMinimo, @PagoMaximo, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdCapacidadPago;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerCapacidadesPago
AS
BEGIN
    SELECT IdCapacidadPago, PagoMinimo, PagoMaximo, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM CapacidadPago
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerCapacidadPagoPorId
    @IdCapacidadPago INT
AS
BEGIN
    SELECT IdCapacidadPago, PagoMinimo, PagoMaximo, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM CapacidadPago
    WHERE IdCapacidadPago = @IdCapacidadPago;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarCapacidadPago
    @IdCapacidadPago INT,
    @PagoMinimo DECIMAL(10,2),
    @PagoMaximo DECIMAL(10,2),
    @Descripcion VARCHAR(50) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE CapacidadPago
    SET PagoMinimo = @PagoMinimo,
        PagoMaximo = @PagoMaximo,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdCapacidadPago = @IdCapacidadPago;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarCapacidadPago
    @IdCapacidadPago INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE CapacidadPago
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdCapacidadPago = @IdCapacidadPago;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: MedioContratacion
=========================================================*/
CREATE TABLE MedioContratacion
(
    IdMedioContratacion INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150),
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarMedioContratacion
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150) = NULL,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO MedioContratacion (Nombre, Descripcion, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Nombre, @Descripcion, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdMedioContratacion;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerMediosContratacion
AS
BEGIN
    SELECT IdMedioContratacion, Nombre, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM MedioContratacion
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerMedioContratacionPorId
    @IdMedioContratacion INT
AS
BEGIN
    SELECT IdMedioContratacion, Nombre, Descripcion, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM MedioContratacion
    WHERE IdMedioContratacion = @IdMedioContratacion;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarMedioContratacion
    @IdMedioContratacion INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150) = NULL,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE MedioContratacion
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdMedioContratacion = @IdMedioContratacion;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarMedioContratacion
    @IdMedioContratacion INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE MedioContratacion
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdMedioContratacion = @IdMedioContratacion;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Usuario
=========================================================*/
CREATE TABLE Usuario
(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    IdRol INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NOT NULL UNIQUE,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL,
    CONSTRAINT FK_Usuario_Rol
        FOREIGN KEY (IdRol)
        REFERENCES Rol(IdRol)
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarUsuario
    @IdRol INT,
    @Nombre VARCHAR(100),
    @Correo VARCHAR(100),
    @Usuario VARCHAR(50),
    @Contrasena VARCHAR(255),
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Usuario (IdRol, Nombre, Correo, Usuario, Contrasena, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@IdRol, @Nombre, @Correo, @Usuario, @Contrasena, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdUsuario;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerUsuarios
AS
BEGIN
    SELECT u.IdUsuario, u.IdRol, r.Nombre AS NombreRol, u.Nombre, u.Correo, 
           u.Usuario, u.Contrasena, u.Activo, u.FechaCreacion, u.UsuarioCreacion, 
           u.FechaModificacion, u.UsuarioModificacion
    FROM Usuario u
    INNER JOIN Rol r ON u.IdRol = r.IdRol
    WHERE u.Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerUsuarioPorId
    @IdUsuario INT
AS
BEGIN
    SELECT u.IdUsuario, u.IdRol, r.Nombre AS NombreRol, u.Nombre, u.Correo, 
           u.Usuario, u.Contrasena, u.Activo, u.FechaCreacion, u.UsuarioCreacion, 
           u.FechaModificacion, u.UsuarioModificacion
    FROM Usuario u
    INNER JOIN Rol r ON u.IdRol = r.IdRol
    WHERE u.IdUsuario = @IdUsuario;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarUsuario
    @IdUsuario INT,
    @IdRol INT,
    @Nombre VARCHAR(100),
    @Correo VARCHAR(100),
    @Usuario VARCHAR(50),
    @Contrasena VARCHAR(255),
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Usuario
    SET IdRol = @IdRol,
        Nombre = @Nombre,
        Correo = @Correo,
        Usuario = @Usuario,
        Contrasena = @Contrasena,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdUsuario = @IdUsuario;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarUsuario
    @IdUsuario INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Usuario
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdUsuario = @IdUsuario;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Cliente
=========================================================*/
CREATE TABLE Cliente
(
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(80) NOT NULL,
    Apellido VARCHAR(80) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    IdGenero INT NOT NULL,
    IdNivelEducativo INT NOT NULL,
    IdRangoEdad INT NOT NULL,
    IdRangoIngresos INT NOT NULL,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL,
    CONSTRAINT FK_Cliente_Genero
        FOREIGN KEY (IdGenero)
        REFERENCES Genero(IdGenero),
    CONSTRAINT FK_Cliente_NivelEducativo
        FOREIGN KEY (IdNivelEducativo)
        REFERENCES NivelEducativo(IdNivelEducativo),
    CONSTRAINT FK_Cliente_RangoEdad
        FOREIGN KEY (IdRangoEdad)
        REFERENCES RangoEdad(IdRangoEdad),
    CONSTRAINT FK_Cliente_RangoIngresos
        FOREIGN KEY (IdRangoIngresos)
        REFERENCES RangoIngresos(IdRangoIngresos)
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarCliente
    @Nombre VARCHAR(80),
    @Apellido VARCHAR(80),
    @Correo VARCHAR(100),
    @Telefono VARCHAR(20),
    @IdGenero INT,
    @IdNivelEducativo INT,
    @IdRangoEdad INT,
    @IdRangoIngresos INT,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Cliente (Nombre, Apellido, Correo, Telefono, IdGenero, IdNivelEducativo, 
                         IdRangoEdad, IdRangoIngresos, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@Nombre, @Apellido, @Correo, @Telefono, @IdGenero, @IdNivelEducativo, 
            @IdRangoEdad, @IdRangoIngresos, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdCliente;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerClientes
AS
BEGIN
    SELECT c.IdCliente, c.Nombre, c.Apellido, c.Correo, c.Telefono, 
           c.IdGenero, g.Nombre AS NombreGenero,
           c.IdNivelEducativo, ne.Nombre AS NombreNivelEducativo,
           c.IdRangoEdad, re.Descripcion AS DescripcionRangoEdad,
           c.IdRangoIngresos, ri.Descripcion AS DescripcionRangoIngresos,
           c.Activo, c.FechaCreacion, c.UsuarioCreacion, 
           c.FechaModificacion, c.UsuarioModificacion
    FROM Cliente c
    INNER JOIN Genero g ON c.IdGenero = g.IdGenero
    INNER JOIN NivelEducativo ne ON c.IdNivelEducativo = ne.IdNivelEducativo
    INNER JOIN RangoEdad re ON c.IdRangoEdad = re.IdRangoEdad
    INNER JOIN RangoIngresos ri ON c.IdRangoIngresos = ri.IdRangoIngresos
    WHERE c.Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerClientePorId
    @IdCliente INT
AS
BEGIN
    SELECT c.IdCliente, c.Nombre, c.Apellido, c.Correo, c.Telefono, 
           c.IdGenero, g.Nombre AS NombreGenero,
           c.IdNivelEducativo, ne.Nombre AS NombreNivelEducativo,
           c.IdRangoEdad, re.Descripcion AS DescripcionRangoEdad,
           c.IdRangoIngresos, ri.Descripcion AS DescripcionRangoIngresos,
           c.Activo, c.FechaCreacion, c.UsuarioCreacion, 
           c.FechaModificacion, c.UsuarioModificacion
    FROM Cliente c
    INNER JOIN Genero g ON c.IdGenero = g.IdGenero
    INNER JOIN NivelEducativo ne ON c.IdNivelEducativo = ne.IdNivelEducativo
    INNER JOIN RangoEdad re ON c.IdRangoEdad = re.IdRangoEdad
    INNER JOIN RangoIngresos ri ON c.IdRangoIngresos = ri.IdRangoIngresos
    WHERE c.IdCliente = @IdCliente;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarCliente
    @IdCliente INT,
    @Nombre VARCHAR(80),
    @Apellido VARCHAR(80),
    @Correo VARCHAR(100),
    @Telefono VARCHAR(20),
    @IdGenero INT,
    @IdNivelEducativo INT,
    @IdRangoEdad INT,
    @IdRangoIngresos INT,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Correo = @Correo,
        Telefono = @Telefono,
        IdGenero = @IdGenero,
        IdNivelEducativo = @IdNivelEducativo,
        IdRangoEdad = @IdRangoEdad,
        IdRangoIngresos = @IdRangoIngresos,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdCliente = @IdCliente;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarCliente
    @IdCliente INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Cliente
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdCliente = @IdCliente;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Pregunta
=========================================================*/
CREATE TABLE Pregunta
(
    IdPregunta INT IDENTITY(1,1) PRIMARY KEY,
    TextoPregunta VARCHAR(300) NOT NULL,
    Categoria VARCHAR(100) NOT NULL,
    TipoControl VARCHAR(50) NOT NULL,
    Obligatoria BIT NOT NULL
        DEFAULT 1,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarPregunta
    @TextoPregunta VARCHAR(300),
    @Categoria VARCHAR(100),
    @TipoControl VARCHAR(50),
    @Obligatoria BIT = 1,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Pregunta (TextoPregunta, Categoria, TipoControl, Obligatoria, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@TextoPregunta, @Categoria, @TipoControl, @Obligatoria, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdPregunta;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerPreguntas
AS
BEGIN
    SELECT IdPregunta, TextoPregunta, Categoria, TipoControl, Obligatoria, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM Pregunta
    WHERE Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerPreguntaPorId
    @IdPregunta INT
AS
BEGIN
    SELECT IdPregunta, TextoPregunta, Categoria, TipoControl, Obligatoria, Activo, 
           FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion
    FROM Pregunta
    WHERE IdPregunta = @IdPregunta;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarPregunta
    @IdPregunta INT,
    @TextoPregunta VARCHAR(300),
    @Categoria VARCHAR(100),
    @TipoControl VARCHAR(50),
    @Obligatoria BIT,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Pregunta
    SET TextoPregunta = @TextoPregunta,
        Categoria = @Categoria,
        TipoControl = @TipoControl,
        Obligatoria = @Obligatoria,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdPregunta = @IdPregunta;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarPregunta
    @IdPregunta INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Pregunta
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdPregunta = @IdPregunta;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Encuesta
=========================================================*/
CREATE TABLE Encuesta
(
    IdEncuesta INT IDENTITY(1,1) PRIMARY KEY,
    FechaEncuesta DATETIME NOT NULL
        DEFAULT GETDATE(),
    IdCliente INT NOT NULL,
    IdUsuario INT NOT NULL,
    IdTipoPrestamo INT NOT NULL,
    IdPlazo INT NOT NULL,
    IdTasaInteres INT NOT NULL,
    IdCapacidadPago INT NOT NULL,
    IdMedioContratacion INT NOT NULL,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL,
    CONSTRAINT FK_Encuesta_Cliente
        FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente),
    CONSTRAINT FK_Encuesta_Usuario
        FOREIGN KEY (IdUsuario)
        REFERENCES Usuario(IdUsuario),
    CONSTRAINT FK_Encuesta_TipoPrestamo
        FOREIGN KEY (IdTipoPrestamo)
        REFERENCES TipoPrestamo(IdTipoPrestamo),
    CONSTRAINT FK_Encuesta_Plazo
        FOREIGN KEY (IdPlazo)
        REFERENCES Plazo(IdPlazo),
    CONSTRAINT FK_Encuesta_TasaInteres
        FOREIGN KEY (IdTasaInteres)
        REFERENCES TasaInteres(IdTasaInteres),
    CONSTRAINT FK_Encuesta_CapacidadPago
        FOREIGN KEY (IdCapacidadPago)
        REFERENCES CapacidadPago(IdCapacidadPago),
    CONSTRAINT FK_Encuesta_MedioContratacion
        FOREIGN KEY (IdMedioContratacion)
        REFERENCES MedioContratacion(IdMedioContratacion)
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarEncuesta
    @IdCliente INT,
    @IdUsuario INT,
    @IdTipoPrestamo INT,
    @IdPlazo INT,
    @IdTasaInteres INT,
    @IdCapacidadPago INT,
    @IdMedioContratacion INT,
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Encuesta (FechaEncuesta, IdCliente, IdUsuario, IdTipoPrestamo, IdPlazo, 
                          IdTasaInteres, IdCapacidadPago, IdMedioContratacion, Activo, 
                          FechaCreacion, UsuarioCreacion)
    VALUES (GETDATE(), @IdCliente, @IdUsuario, @IdTipoPrestamo, @IdPlazo, 
            @IdTasaInteres, @IdCapacidadPago, @IdMedioContratacion, @Activo, 
            GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdEncuesta;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerEncuestas
AS
BEGIN
    SELECT e.IdEncuesta, e.FechaEncuesta, e.IdCliente, 
           c.Nombre + ' ' + c.Apellido AS NombreCliente,
           e.IdUsuario, u.Nombre AS NombreUsuario,
           e.IdTipoPrestamo, tp.Nombre AS NombreTipoPrestamo,
           e.IdPlazo, p.Meses AS MesesPlazo,
           e.IdTasaInteres, ti.Descripcion AS DescripcionTasaInteres,
           e.IdCapacidadPago, cp.Descripcion AS DescripcionCapacidadPago,
           e.IdMedioContratacion, mc.Nombre AS NombreMedioContratacion,
           e.Activo, e.FechaCreacion, e.UsuarioCreacion, 
           e.FechaModificacion, e.UsuarioModificacion
    FROM Encuesta e
    INNER JOIN Cliente c ON e.IdCliente = c.IdCliente
    INNER JOIN Usuario u ON e.IdUsuario = u.IdUsuario
    INNER JOIN TipoPrestamo tp ON e.IdTipoPrestamo = tp.IdTipoPrestamo
    INNER JOIN Plazo p ON e.IdPlazo = p.IdPlazo
    INNER JOIN TasaInteres ti ON e.IdTasaInteres = ti.IdTasaInteres
    INNER JOIN CapacidadPago cp ON e.IdCapacidadPago = cp.IdCapacidadPago
    INNER JOIN MedioContratacion mc ON e.IdMedioContratacion = mc.IdMedioContratacion
    WHERE e.Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerEncuestaPorId
    @IdEncuesta INT
AS
BEGIN
    SELECT e.IdEncuesta, e.FechaEncuesta, e.IdCliente, 
           c.Nombre + ' ' + c.Apellido AS NombreCliente,
           e.IdUsuario, u.Nombre AS NombreUsuario,
           e.IdTipoPrestamo, tp.Nombre AS NombreTipoPrestamo,
           e.IdPlazo, p.Meses AS MesesPlazo,
           e.IdTasaInteres, ti.Descripcion AS DescripcionTasaInteres,
           e.IdCapacidadPago, cp.Descripcion AS DescripcionCapacidadPago,
           e.IdMedioContratacion, mc.Nombre AS NombreMedioContratacion,
           e.Activo, e.FechaCreacion, e.UsuarioCreacion, 
           e.FechaModificacion, e.UsuarioModificacion
    FROM Encuesta e
    INNER JOIN Cliente c ON e.IdCliente = c.IdCliente
    INNER JOIN Usuario u ON e.IdUsuario = u.IdUsuario
    INNER JOIN TipoPrestamo tp ON e.IdTipoPrestamo = tp.IdTipoPrestamo
    INNER JOIN Plazo p ON e.IdPlazo = p.IdPlazo
    INNER JOIN TasaInteres ti ON e.IdTasaInteres = ti.IdTasaInteres
    INNER JOIN CapacidadPago cp ON e.IdCapacidadPago = cp.IdCapacidadPago
    INNER JOIN MedioContratacion mc ON e.IdMedioContratacion = mc.IdMedioContratacion
    WHERE e.IdEncuesta = @IdEncuesta;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarEncuesta
    @IdEncuesta INT,
    @IdCliente INT,
    @IdUsuario INT,
    @IdTipoPrestamo INT,
    @IdPlazo INT,
    @IdTasaInteres INT,
    @IdCapacidadPago INT,
    @IdMedioContratacion INT,
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Encuesta
    SET IdCliente = @IdCliente,
        IdUsuario = @IdUsuario,
        IdTipoPrestamo = @IdTipoPrestamo,
        IdPlazo = @IdPlazo,
        IdTasaInteres = @IdTasaInteres,
        IdCapacidadPago = @IdCapacidadPago,
        IdMedioContratacion = @IdMedioContratacion,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdEncuesta = @IdEncuesta;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarEncuesta
    @IdEncuesta INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Encuesta
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdEncuesta = @IdEncuesta;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

/*=========================================================
    TABLA: Respuesta
=========================================================*/
CREATE TABLE Respuesta
(
    IdRespuesta INT IDENTITY(1,1) PRIMARY KEY,
    IdEncuesta INT NOT NULL,
    IdPregunta INT NOT NULL,
    Valor VARCHAR(500) NOT NULL,
    Activo BIT NOT NULL
        DEFAULT 1,
    FechaCreacion DATETIME NOT NULL
        DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(50) NULL,
    CONSTRAINT FK_Respuesta_Encuesta
        FOREIGN KEY (IdEncuesta)
        REFERENCES Encuesta(IdEncuesta),
    CONSTRAINT FK_Respuesta_Pregunta
        FOREIGN KEY (IdPregunta)
        REFERENCES Pregunta(IdPregunta)
);
GO

-- CREATE
CREATE PROCEDURE sp_InsertarRespuesta
    @IdEncuesta INT,
    @IdPregunta INT,
    @Valor VARCHAR(500),
    @UsuarioCreacion VARCHAR(50),
    @Activo BIT = 1
AS
BEGIN
    INSERT INTO Respuesta (IdEncuesta, IdPregunta, Valor, Activo, FechaCreacion, UsuarioCreacion)
    VALUES (@IdEncuesta, @IdPregunta, @Valor, @Activo, GETDATE(), @UsuarioCreacion);
    
    SELECT SCOPE_IDENTITY() AS IdRespuesta;
END
GO

-- READ (Todos)
CREATE PROCEDURE sp_ObtenerRespuestas
AS
BEGIN
    SELECT r.IdRespuesta, r.IdEncuesta, r.IdPregunta, 
           p.TextoPregunta, r.Valor, r.Activo, 
           r.FechaCreacion, r.UsuarioCreacion, 
           r.FechaModificacion, r.UsuarioModificacion
    FROM Respuesta r
    INNER JOIN Pregunta p ON r.IdPregunta = p.IdPregunta
    WHERE r.Activo = 1;
END
GO

-- READ (Por ID)
CREATE PROCEDURE sp_ObtenerRespuestaPorId
    @IdRespuesta INT
AS
BEGIN
    SELECT r.IdRespuesta, r.IdEncuesta, r.IdPregunta, 
           p.TextoPregunta, r.Valor, r.Activo, 
           r.FechaCreacion, r.UsuarioCreacion, 
           r.FechaModificacion, r.UsuarioModificacion
    FROM Respuesta r
    INNER JOIN Pregunta p ON r.IdPregunta = p.IdPregunta
    WHERE r.IdRespuesta = @IdRespuesta;
END
GO

-- READ (Por Encuesta)
CREATE PROCEDURE sp_ObtenerRespuestasPorEncuesta
    @IdEncuesta INT
AS
BEGIN
    SELECT r.IdRespuesta, r.IdEncuesta, r.IdPregunta, 
           p.TextoPregunta, p.Categoria, p.TipoControl,
           r.Valor, r.Activo, 
           r.FechaCreacion, r.UsuarioCreacion, 
           r.FechaModificacion, r.UsuarioModificacion
    FROM Respuesta r
    INNER JOIN Pregunta p ON r.IdPregunta = p.IdPregunta
    WHERE r.IdEncuesta = @IdEncuesta AND r.Activo = 1;
END
GO

-- UPDATE
CREATE PROCEDURE sp_ActualizarRespuesta
    @IdRespuesta INT,
    @IdEncuesta INT,
    @IdPregunta INT,
    @Valor VARCHAR(500),
    @UsuarioModificacion VARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Respuesta
    SET IdEncuesta = @IdEncuesta,
        IdPregunta = @IdPregunta,
        Valor = @Valor,
        Activo = @Activo,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRespuesta = @IdRespuesta;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO

-- DELETE (Lógico)
CREATE PROCEDURE sp_EliminarRespuesta
    @IdRespuesta INT,
    @UsuarioModificacion VARCHAR(50)
AS
BEGIN
    UPDATE Respuesta
    SET Activo = 0,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE IdRespuesta = @IdRespuesta;
    
    SELECT @@ROWCOUNT AS FilasAfectadas;
END
GO