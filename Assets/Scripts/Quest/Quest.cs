using System.Collections;
using System.Collections.Generic;

public class Quest
{
    public readonly QuestInformation information;
    public int currentProgress {get; private set;}

    public Quest(QuestInformation info)
    {
    	information = info;
    }
}
