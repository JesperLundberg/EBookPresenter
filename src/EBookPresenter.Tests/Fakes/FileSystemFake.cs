using System;
using System.Collections.Generic;

using EBookPresenter.Wrappers;

namespace EBookPresenter.Tests.Fakes;

public class FileSystemFake : IFileSystem
{
    private static int folderCount;

    public IEnumerable<string> GetDirectories(string path)
    {
        var directoriesToReturn = folderCount switch
        {
            0 => new[]
            {
                "folder1", "folder2", "folder3"
            },
            1 => new[]
            {
                "folder4"
            },
            _ => Array.Empty<string>()
        };

        folderCount += 1;

        return directoriesToReturn;
    }

    public IEnumerable<string> GetFiles(string path)
    {
        var filesToReturn = folderCount switch
        {
            1 => new[]
            {
                "file1.epub", "file2.epub", "file3.epub"
            },
            2 => new[]
            {
                "file4.epub"
            },
            3 => new[]
            {
                "file5.epub", "file6.epub"
            },
            4 => new[]
            {
                "file7.epub", "file8.epub"
            },
            _ => Array.Empty<string>()
        };

        return filesToReturn;
    }
}