﻿namespace Shared.DataTransferObjects
{
    public record EntidadForUpdateDto(
        string PrimerNombre,
        string SegundoNombre,
        string PrimerApellido,
        string SegundoApellido,
        string UsuarioAcceso,
        byte[] ContrasennaHash,
        byte[] ContrasennaSalt
        );
}
