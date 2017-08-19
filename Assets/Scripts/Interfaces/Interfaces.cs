using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasura
{
    int darTipo();
}

public interface IRecolector<T>
{
    void recolectar(T Arecolectar);
}

public interface IGeneradora
{
    void generar();
}

public interface IRecogedor
{
    void recoger();
}
