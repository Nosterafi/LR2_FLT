using LexicalAnalysis;
using LexicalMachine;
using Transliteration;

namespace LexicalAnalysis;

/// <summary>
/// Класс для создания и настройки лексического анализатора с предопределенными автоматами.
/// </summary>
public static class AnalyzerCreator
{
    /// <summary>
    /// Создает и настраивает лексический анализатор с автоматами для чисел и идентификаторов.
    /// </summary>
    public static LexicalAnalyzer Create(string text)
    {
        var result = new LexicalAnalyzer(text);
        result.Machines.Add(CreateNumberMachine());
        result.Machines.Add(CreateIdentifierMachine());

        return result;
    }

    /// <summary>
    /// Создает конечный автомат для распознавания чисел, соответствующмх регулярному выражению (011)*001(010)*.
    /// </summary>
    private static StateMachine CreateNumberMachine()
    {
        // Создание состояний автомата для чисел
        var stateA = new State("A");
        var stateBE = new State("B E");
        var stateC = new State("C");
        var stateD = new State("D");
        var stateF = new State("F", true);
        var stateG = new State("G");
        var stateH = new State("H");

        // Правила переходов для состояния A (начального)
        stateA.Rules[new ClassifiedLetter('0')] = stateBE;  // 0 → B_E

        // Правила переходов для состояния B E
        stateBE.Rules[new ClassifiedLetter('0')] = stateD;  // 0 → D
        stateBE.Rules[new ClassifiedLetter('1')] = stateC;   // 1 → C

        // Правила переходов для состояния C
        stateC.Rules[new ClassifiedLetter('1')] = stateA;    // 1 → A

        // Правила переходов для состояния D
        stateD.Rules[new ClassifiedLetter('1')] = stateF;    // 1 → F (принимающее)

        // Правила переходов для состояния F (принимающего)
        stateF.Rules[new ClassifiedLetter('0')] = stateG;   // 0 → G

        // Правила переходов для состояния G
        stateG.Rules[new ClassifiedLetter('1')] = stateH;    // 1 → H

        // Правила переходов для состояния H
        stateH.Rules[new ClassifiedLetter('0')] = stateF;   // 0 → F (принимающее)

        return new StateMachine(stateA, TokenKind.Number, [new ClassifiedLetter('0'), new ClassifiedLetter('1')]);
    }

    /// <summary>
    /// Создает конечный автомат для распознавания идентификаторов по регулярному выражению (a|b|c|d)+.
    /// </summary>
    private static StateMachine CreateIdentifierMachine()
    {
        // Создание состояний автомата для идентификаторов
        var stateA = new State("A");
        var stateB = new State("B");
        var stateAFin = new State("A FIN", true);
        var stateBFin = new State("B FIN", true);

        // Правила переходов для состояния A
        stateA.Rules[new ClassifiedLetter('a')] = stateBFin;   // a → B_FIN
        stateA.SetRulesForNotA(stateAFin);   // b,c,d → A_FIN

        // Правила переходов для состояния B
        stateB.Rules[new ClassifiedLetter('a')] = stateB;         // a → B (накапливаем 'a')
        stateB.SetRulesForNotA(stateAFin);   // b,c,d → A_FIN

        // Правила переходов для состояния A_FIN
        stateAFin.Rules[new ClassifiedLetter('a')] = stateBFin;   // a → B_FIN
        stateAFin.SetRulesForNotA(stateAFin); // b,c,d → A_FIN

        // Правила переходов для состояния B_FIN
        stateBFin.Rules[new ClassifiedLetter('a')] = stateB;      // a → B
        stateBFin.SetRulesForNotA(stateAFin); // b,c,d → A_FIN

        return new StateMachine(stateA, TokenKind.Identifier, [
            new ClassifiedLetter('a'),
            new ClassifiedLetter('b'),
            new ClassifiedLetter('c'),
            new ClassifiedLetter('d'),
            ]);
    }

    /// <summary>
    /// Устанавливает правила для символов b,c,d.
    /// </summary>
    private static void SetRulesForNotA(this State currentState, State nextState)
    {
        var validSymbols = "bcd";

        foreach (var symbol in validSymbols)
            currentState.Rules[new ClassifiedLetter(symbol)] = nextState;
    }
}