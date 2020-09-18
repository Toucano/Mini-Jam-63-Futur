using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverScript : MonoBehaviour
{
    private Coroutine instructionCoroutine;
    [SerializeField] List<Instruction> instructions = new List<Instruction>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && instructionCoroutine == null)
        {
            StartCoroutine(DoInstructionCoroutine());
        }
    }

    private IEnumerator DoInstructionCoroutine()
    {

        //you would set this through whatever input you are using
        for (int i = 0; i < instructions.Count; i++)
        {
            while (!instructions[i].CheckComplete())
            {
                instructions[i].ExecuteInstruction();
                yield return null;
            }
        }
        //all instrucitons done
    }

    public class Instruction
    {
        string intructionName;

        public Instruction(string intructionName)
        {
            this.intructionName = intructionName;
        }

        public bool CheckComplete()
        {
            //implementation
            return true;
        }

        public void ExecuteInstruction()
        {
            //Do the logic here
        }
    }
}