using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GreatCircleSaveManager
{
    public class GreatCircleSavePathCollection : IList<GreatCircleSavePath>
    {
        private List<GreatCircleSavePath> Paths = new List<GreatCircleSavePath>();

        public int Count => Paths.Count;

        public bool IsReadOnly => false;

        public GreatCircleSavePathCollection() { }

        public GreatCircleSavePathCollection(IEnumerable<GreatCircleSavePath> paths) => Paths.AddRange(paths);

        public GreatCircleSavePath this[int index] {
            get {
                return Paths[index];
            }
            set {
                Paths[index] = value;
            }
        }

        public int IndexOf(GreatCircleSavePath path) => Paths.IndexOf(path);

        public void Insert(int index, GreatCircleSavePath path) => Paths.Insert(index, path);

        public void RemoveAt(int index) => Paths.RemoveAt(index);

        public void Add(GreatCircleSavePath path) => Paths.Add(path);

        public void Clear() => Paths.Clear();

        public bool Contains(GreatCircleSavePath path) => Paths.Contains(path);

        public void CopyTo(GreatCircleSavePath[] array, int index) => Paths.CopyTo(array, index);

        public bool Remove(GreatCircleSavePath path) => Paths.Remove(path);

        public IEnumerator<GreatCircleSavePath> GetEnumerator() => Paths.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public GreatCircleSavePath Get(int index) => Paths[index];

        public bool SaveExists(string id, out GreatCircleSavePath save) {
            foreach(var single in Paths) {
                if (single.Identifier == id) {
                    save = single;
                    return true;
                }
            }
            save = null;
            return false;
        }

        public GreatCircleSavePath GetSave(string id) {
            GreatCircleSavePath save;
            SaveExists(id, out save);
            return save;
        }

        public string[] GetIdentifiers() => Paths.Select(single => single.Identifier).ToArray();
    }
}
