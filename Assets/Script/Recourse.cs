using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Acciones
{
    Iddle,
    rotate,
    move,
    Reaccionar
}

public enum Nombres
{
    Eddy,
    Sergio,
    Nahed,
    dilan,
    sebastian,
    Luis,
    Santiago,
    Abdel,
    Antonio,
    Alexis,
    Jorge,
    Baruk,
    alejandro,
    victor,
    yency,
    Losbsan,
    Mauricio,
    kebin,
    smith,
    Magneto
}
public struct CitizenInfo
{
    public int age;
    public Nombres names;
}


public enum Gusto
{
    PiernaDerecha,
    PiernaIzquierda,
    BrazoDerecho,
    BrazoIzquierdo,
    Cabeza
}

public struct ZombieInfo
{
    public Gusto gustoZombie;
    public int age;
}


