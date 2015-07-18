namespace ConsoleApplication7
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// A database entity that represents either a file or a folder.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class FileSystemEntity
    {
        /// <summary>
        /// Gets or sets the primary key for this entity.
        /// Normally set by the database ORM.
        /// </summary>
        public int FileSystemEntityId { get; set; }

        /// <summary>
        /// Gets or sets the leaf name of this folder or file.
        /// </summary>
        public string Name { get; set; }

        public int? ParentFileSystemEntityId { get; set; }

        /// <summary>
        /// Gets or sets the parent folder for htis folder or file.
        /// </summary>
        [ForeignKey(nameof(ParentFileSystemEntityId))]
        public virtual FileSystemEntity Parent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this entity represents a file.
        /// </summary>
        /// <value><c>true</c> if this entity represents a file; <c>false</c> if this entity represents a folder.</value>
        public bool IsFile { get; set; }

        /// <summary>
        /// Gets or sets a collection of files contained by this folder (when <see cref="IsFile"/> is <c>false</c>).
        /// </summary>
        public virtual ICollection<FileSystemEntity> Children { get; set; } = new List<FileSystemEntity>();

        /// <summary>
        /// Gets the path of this folder or file, relative to the root of the repo.
        /// </summary>
        public string RelativePath => this.Parent != null ? Path.Combine(this.Parent.RelativePath, this.Name) : this.Name;

        /// <summary>
        /// Gets the value to display in the <see cref="DebuggerDisplayAttribute"/>.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => this.RelativePath + (this.IsFile ? string.Empty : "\\");
    }
}
