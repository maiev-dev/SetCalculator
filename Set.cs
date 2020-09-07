using System;
using System.Collections.Generic;


public class Set<T>
{
    private List<T> setMembers { public get; set; }
    private List<T> universalSetMembers;
    private List<bool> describeVector { public get; set; }
    
    public Set(List<T> universalSetMembers = null,params T[]  members)
	{
        setMembers = new List<T>();
        this.universalSetMembers = univarsalSetMembers;
        foreach (var member in members)
        {
            this.Push(member);
        }
        InitializeDeskribeVector();
	}

    

    public void Push(List<T> universalSetMembers, T value)
    {
        if (!setMembers.Contains(value) && universalSetMembers.Contains(value))
        {
            setMembers.Add(value);
        }
        else
        {
            throw new ArgumentException("Такой элемент уже есть во множестве или он не содержится в универсальном множестве, проверьте ввод");
        }
    }

    private void InitializeDeskribeVector()
    {
        this.describeVector = new List<bool>();
        for (int i = 0; i < setMembers.Count; i++)
        {
            describeVector[i] = universalSetMembers.Contains(setMembers);
        }
    }
}