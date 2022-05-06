#include <unistd.h>
#include <stdio.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <sys/sysmacros.h>
#include <pwd.h>
#include <grp.h>
#include <time.h>

void print_file_type(struct stat fileStat)
{
    if (S_ISDIR(fileStat.st_mode))
    {
        printf("directory");
    }
    if (S_ISCHR(fileStat.st_mode))
    {
        printf("char device");
    }
    if (S_ISFIFO(fileStat.st_mode))
    {
        printf("FIFO pipe");
    }
    if (S_ISBLK(fileStat.st_mode))
    {
        printf("block device");
    }
    if (S_ISREG(fileStat.st_mode))
    {
        printf("regular file");
    }
    return;
}

void print_file_access(struct stat fileStat)
{
    if (S_ISDIR(fileStat.st_mode))
    {
        printf("d");
    }
    else
    {
        printf("-");
    }
    printf((fileStat.st_mode & S_IRUSR) ? "r" : "-");
    printf((fileStat.st_mode & S_IWUSR) ? "w" : "-");
    if (fileStat.st_mode & S_ISUID)
    {
        printf("s");
    }
    else
    {
        printf((fileStat.st_mode & S_IXUSR) ? "x" : "-");
    }

    printf((fileStat.st_mode & S_IRGRP) ? "r" : "-");
    printf((fileStat.st_mode & S_IWGRP) ? "w" : "-");
    if (fileStat.st_mode & S_ISGID)
    {
        printf("s");
    }
    else
    {
        printf((fileStat.st_mode & S_IXGRP) ? "x" : "-");
    }

    printf((fileStat.st_mode & S_IROTH) ? "r" : "-");
    printf((fileStat.st_mode & S_IWOTH) ? "w" : "-");

    printf((fileStat.st_mode & S_IXOTH) ? "x" : "-");
}

int main(int argc, char **argv)
{
    if (argc != 2)
        return 1;

    struct stat fileStat;
    struct passwd *user;
    struct group *group;
    char access_time[20];
    char modify_time[20];
    char status_change_time[20];

    if (stat(argv[1], &fileStat) < 0)
    {
        printf("Error");
        return 1;
    }
    printf("File: %s\n", argv[1]);
    printf("Size: %d", fileStat.st_size);
    printf("\tBlocks: %d", fileStat.st_blocks);
    printf("\tIO Block: %d\t", fileStat.st_blksize);
    print_file_type(fileStat);
    printf("\t Links:%d", fileStat.st_nlink);
    printf("\n");
    printf("Device minor number: %d\t", minor(fileStat.st_dev));
    printf("Device major number: %d\t", major(fileStat.st_dev));
    printf("Inode number: %d", fileStat.st_ino);
    printf("\n");
    printf("Access: ");
    print_file_access(fileStat);
    printf("\tOwner UID:%d\t", fileStat.st_uid);
    user = getpwuid(fileStat.st_uid);
    printf("Owner name:");
    printf(user ? user->pw_name : "uknown user");
    if (user != NULL)
    {
        group = getgrgid(user->pw_gid);
    }
    printf("\tOwner group:");
    printf(group ? group->gr_name : "uknown group");
    printf("\n");
    strftime(access_time, 20, "%Y-%m-%d %H:%M:%S", localtime(&fileStat.st_atime));
    strftime(modify_time, 20, "%Y-%m-%d %H:%M:%S", localtime(&fileStat.st_mtime));
    strftime(status_change_time, 20, "%Y-%m-%d %H:%M:%S", localtime(&fileStat.st_ctime));
    printf("Last access time:\t%s\n", access_time);
    printf("Last modification time:\t%s\n", modify_time);
    printf("Last stat change time:\t%s\n", status_change_time);
    return 0;
}
