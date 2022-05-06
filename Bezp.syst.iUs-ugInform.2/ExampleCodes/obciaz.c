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
    assert(argc > 3);
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

    for (int i = 0; i < atoi(argv[3]) - 1; i++)
    {
        int pid = fork();
        if (pid < 0)
        {
            printf("Error");
            exit(1);
        }
        else if (pid == 0)
        {
            printf("Child (%d): %d\n", i + 1, getpid());
            while (1)
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
                if (bytesRead == 0)
                {
                    lseek(oldDesc, 0, SEEK_SET);
                }
            }
        }
    }
    close(oldDesc);
    close(newDesc);
    exit(EXIT_SUCCESS);
}