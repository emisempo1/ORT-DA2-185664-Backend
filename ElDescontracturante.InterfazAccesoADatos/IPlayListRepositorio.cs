﻿using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface IPlaylistRepositorio
    {
        void Agregar(Playlist unaPlaylist);
        Playlist ObtenerPlaylist(string nombre);

        List<Playlist> ObtenerPlaylist(string[] nombre);
    }
}
