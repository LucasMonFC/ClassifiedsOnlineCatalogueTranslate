namespace ClassifiedsOnlineCatalogue;

internal enum OrderState {
    Connect,       // -> NotConnected, Viewing or NewMagazine
    NotConnected,  // -> Connect
    NewMagazine,   // -> Invalid
    Invalid,       // -> Downloading
    Downloading,   // -> Downloaded
    Downloaded,    // -> Viewing
    DownloadError, // -> Connect
    Viewing,       // -> NewMagazine, Connect
}
