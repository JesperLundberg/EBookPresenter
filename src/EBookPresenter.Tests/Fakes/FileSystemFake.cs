using System;
using System.Collections.Generic;
using System.Linq;
using EBookPresenter.Wrappers;

namespace EBookPresenter.Tests.Fakes;

public class FileSystemFake : IFileSystem
{
    private static int folderCount;

    public IEnumerable<string> GetDirectories(string path)
    {
        var directoriesToReturn = folderCount switch
        {
            0 => ["folder1", "folder2", "folder3"],
            1 => ["folder4"],
            _ => Array.Empty<string>()
        };

        folderCount += 1;

        return directoriesToReturn;
    }

    public IEnumerable<string> GetFiles(string path)
    {
        var filesToReturn = folderCount switch
        {
            1 => ["file1.epub", "file2.epub", "file3.epub"],
            2 => ["file4.epub"],
            3 => ["file5.epub", "file6.epub"],
            4 => ["file7.epub", "file8.epub"],
            _ => Enumerable.Empty<string>()
        };

        return filesToReturn;
    }
}

