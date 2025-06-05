using System;
using System.Runtime.InteropServices;

unsafe class Program
{
    struct Animal
    {
        public int Id;
        public string Name;
        public Animal* LeftTree;
        public Animal* RightTree;
    }

    class AnimalTree
    {
        public Animal* root;
        public void AddAnimal(int id, string name)
        {
            if (root == null)
            {
                root = (Animal*)NativeMemory.Alloc((nuint)sizeof(Animal));
                root->Id = id;
                root->Name = name;
                root->LeftTree = null;
                root->RightTree = null;
                return;
            }
            Animal* current = root;
            while (true)
            {
                if (id < current->Id)
                {
                    if (current->LeftTree == null)
                    {
                        current->LeftTree = (Animal*)NativeMemory.Alloc((nuint)sizeof(Animal));
                        current->LeftTree->Id = id;
                        current->LeftTree->Name = name;
                        current->LeftTree->LeftTree = null;
                        current->LeftTree->RightTree = null;
                        break;
                    }
                    current = current->LeftTree;
                }
                else
                {
                    if (current->RightTree == null)
                    {
                        current->RightTree = (Animal*)NativeMemory.Alloc((nuint)sizeof(Animal));
                        current->RightTree->Id = id;
                        current->RightTree->Name = name;
                        current->RightTree->LeftTree = null;
                        current->RightTree->RightTree = null;
                        break;
                    }
                    current = current->RightTree;
                }
            }
        }

        public void Print()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пустое.");
                return;
            }
            Animal** queue = stackalloc Animal*[32];
            int front = 0;
            int rear = 0;
            int level = 0;
            queue[rear++] = root;
            while (front < rear)
            {
                int levelSize = rear - front;
                if (level == 0) Console.Write("Корень: ");
                else Console.Write($"Уровень {level}: ");

                for (int i = 0; i < levelSize; i++)
                {
                    Animal* current = queue[front++];
                    Console.Write($"{current->Id} ({current->Name}) ");
                    if (current->LeftTree != null) queue[rear++] = current->LeftTree;
                    if (current->RightTree != null) queue[rear++] = current->RightTree;
                }
                Console.WriteLine();
                level++;
            }
        }
    }
    static unsafe void Main()
    {
        AnimalTree tree = new AnimalTree();
        tree.AddAnimal(5, "Кенгуру");
        tree.AddAnimal(7, "Бык");
        tree.AddAnimal(3, "Капибара");
        tree.AddAnimal(2, "Кошка");
        tree.AddAnimal(4, "Утконос");
        tree.AddAnimal(6, "Голубь");
        tree.AddAnimal(8, "Слон");
        tree.Print();
    }
}
