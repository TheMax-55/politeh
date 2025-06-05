using System;

unsafe class Program
{
    struct Animal
    {
        public int id;
        public fixed char name[64];
        public Animal* leftTree;
        public Animal* rightTree;
        public Animal(int id, string name)
        {
            this.id = id;
            fixed (char* syms = this.name)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    syms[i] = name[i];
                }
            }
            this.leftTree = null;
            this.rightTree = null;
        }
        public string printName()
        {
            fixed (char* syms = name)
            {
                return new string(syms);
            }
        }
    }
    class AnimalTree
    {
        public Animal* root;
        public Animal[] animals = new Animal[64];
        public int num = 0;
        public void AddAnimal(int id, string name)
        {
            animals[num] = new Animal(id, name);
            fixed (Animal* newNode = &animals[num])
            {
                if (root == null)
                {
                    root = newNode;
                    num++;
                    return;
                }
                Animal* current = root;
                while (true)
                {
                    if (id < current->id)
                    {
                        if (current->leftTree == null)
                        {
                            current->leftTree = newNode;
                            break;
                        }
                        current = current->leftTree;
                    }
                    else
                    {
                        if (current->rightTree == null)
                        {
                            current->rightTree = newNode;
                            break;
                        }
                        current = current->rightTree;
                    }
                }
                num++;
            }
        }
        public void Print()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пустое.");
                return;
            }
            Animal** queue = stackalloc Animal*[64];
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
                    Console.Write($"{current->id} ({current->printName()}) ");
                    if (current->leftTree != null) queue[rear++] = current->leftTree;
                    if (current->rightTree != null) queue[rear++] = current->rightTree;
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
