using UnityEngine;
using System.Collections;
/// <summary>
/// Classe Generica responsavel por implementação de Classes Singleton
/// Singleton é um padrão de projeto de software.
/// Este padrão garante a existência de apenas uma instância de uma classe, mantendo um ponto global de acesso ao seu objeto.
/// Em jogos bastante usado em classes de Gerenciamento Unico ... como Som, SceneManager, GameManager ... ETC
/// 
/// Quando Declaramos um tipo <T> queremos dizer que a classe que herdar essa classe, ouseja ... seu filho , poderá atribuir um tipo de objeto para o Singleton,
/// o conceito já é alto explicativo ele passa como complemento a propria classe
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Declaromos um variavel do tipo da classe criada
    /// </summary>
    private static T m_instance;

    /// <summary>
    /// Metodo Get para poder buscar a referencia desse objeto (referencia Unica)
    /// </summary>
    public static T instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.FindObjectOfType<T>();
            }
            return m_instance;
        }
    }
}