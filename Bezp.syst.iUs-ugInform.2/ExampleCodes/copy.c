#include <stdio.h>
#include <stdlib.h>
#include <assert.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
int main(int argc, char *argv[])
{
    int bytesRead = 1;
    int bytesWritten = 1;
    assert(argc > 2);
    char buf[512];

    int oldDesc = open(argv[1], O_RDONLY);
    if (oldDesc < 0)
    {
        perror("blad otwarcia pliku");
        exit(EXIT_FAILURE);
    }

    int newDesc = open(argv[2], O_CREAT | O_WRONLY, 0600);
    if (newDesc < 0)
    {
        perror("blad utworzenia pliku");
        exit(EXIT_FAILURE);
    }
    while (bytesRead)
    {
        bytesRead = read(oldDesc, buf, 512);
        write(newDesc, buf, bytesRead);
        if (bytesRead < 0)
        {
            perror("blad odczytu z pliku");
            exit(EXIT_FAILURE);
        }
        if (bytesWritten < 0)
        {
            perror("Blad zapisu do pliku");
            exit(EXIT_FAILURE);
        }
    }
    close(oldDesc);
    close(newDesc);
    return EXIT_SUCCESS;
}