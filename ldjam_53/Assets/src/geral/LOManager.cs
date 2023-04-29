/*
Description Script:
Name:
Date:
Upgrade:
*/
using UnityEngine;
using System.Collections.Generic;

public class PoolManager : Singleton<PoolManager>
{
    private Dictionary<string, List<GameObject>> PoolManagerDictionary;   // Dicionario onde contem as lista que for preciso para criar os objetos

    /// <summary>
    /// Inicializa o dicionario
    /// </summary>
    void Awake()
    {
        PoolManagerDictionary = new Dictionary<string, List<GameObject>>();
    }

    /// <summary>
    /// Criar uma lista de GameObjects
    /// </summary>
    /// <param name="_key"> Nome da chave que vai servir de referencia para utilizar a lista </param>
    public void create(string _key)
    {
        if (!PoolManagerDictionary.ContainsKey(_key))
            PoolManagerDictionary.Add(_key, new List<GameObject>());
    }

    /// <summary>
    /// Metodo responsavel por deletar uma lista de objetos dentro do dicionario
    /// </summary>
    /// <param name="_key"> Referencia da lista a ser deletada </param>
    public void delete(string _key)
    {
        PoolManagerDictionary.Remove(_key);
    }

    /// <summary>
    /// Metodo responsavel por limpar todo dicionario
    /// Usado quando uma missão chega ao final
    /// </summary>
    public void clear()
    {
        PoolManagerDictionary.Clear();
    }

    /// <summary>
    /// Metodo responsavel para retornar uma lista de GameObjects
    /// </summary>
    /// <param name="_key"> Nome da chave para buscar a lista  </param>
    /// <returns></returns>
    public List<GameObject> load(string _key)
    {
        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos");
            return null;
        }
        else
        {
            List<GameObject> _newList;
            PoolManagerDictionary.TryGetValue(_key, out _newList);
            return _newList;
        }
    }

    /// <summary>
    /// Metodo responsavel para criar e adicionar mais um objeto a uma das lista disponivel
    /// </summary>
    /// <param name="_object"> Objeto a ser adicionado dentro da lista </param>
    /// <param name="_key"> Referencia onde vai ser adicionar este objeto </param>
    public GameObject add(string _key, GameObject _object)
    {
        GameObject __object;

        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos, ele vai ser criado para que os objetos seja adicionado");
            create(_key);
            add(_key, _object);
            return null;
        }
        else
        {
            __object = Instantiate(_object) as GameObject;
            __object.name = _key;
            __object.SetActive(false);
            PoolManagerDictionary[_key].Add(__object);
            return __object;
        }
    }

    /// <summary>
    /// Metodo responsavel para adicionar uma lista de objetos já existentes dentro da lista
    /// </summary>
    /// <param name="_object"> Objeto a ser adicionado dentro da lista </param>
    /// <param name="_key"> Referencia onde vai ser adicionar este objeto </param>
    public void addObjectCreated(string _key, GameObject _object)
    {
        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos, ele vai ser criado para que os objetos seja adicionado");
            create(_key);
            addObjectCreated(_key, _object);
        }
        else
        {
            _object.SetActive(false);
            PoolManagerDictionary[_key].Add(_object);
        }
    }

    /// <summary>
    /// Metodo responsavel para adicionar uma lista de objetos já existentes dentro da lista
    /// </summary>
    /// <param name="_object"> lista de objetos a ser adicionado dentro da lista </param>
    /// <param name="_key"> Referencia onde vai ser adicionar este objeto </param>
    public void addObjectCreated(string _key, List<GameObject> _object)
    {
        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos, ele vai ser criado para que os objetos seja adicionado");
            create(_key);
            addObjectCreated(_key, _object);
        }
        else
        {
            for (int i = 0; i < _object.Count; i++)
            {
                _object[i].SetActive(false);
                PoolManagerDictionary[_key].Add(_object[i]);
            }
        }
    }

    /// <summary>
    /// Método responsável para inserir uma lista de GameObject dentro do dicionário
    /// </summary>
    /// <param name="_object"> O prefab do objeto que vai ser clonado para adicionar na lista </param>
    /// <param name="_amount"> Quantidade de objetos daquele tipo que vai ser criado</param>
    /// <param name="_key"> Referencia onde vai ser criado a lista dentro do dicionario</param>
    public void createList(string _key, GameObject _object, int _amount)
    {
        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos, ele vai ser criado para que os objetos seja adicionado");
            create(_key);
            createList(_key, _object, _amount);
        }
        else
        {
            for (int i = 0; i < _amount; i++)
            {
                GameObject __object = Instantiate(_object) as GameObject;
                __object.name = _key;
                __object.SetActive(false);
                PoolManagerDictionary[_key].Add(__object);
            }
        }
    }

    /// <summary>
    /// Responsável por retornar um objeto que está disponivel para ser usado dentro da lista de objeto
    /// </summary>
    /// <param name="_key"> Referência na qual a lista está armazenando os objetos que podem estar disponiveis </param>
    /// <returns></returns>
    public GameObject GetObjectDictionary(string _key)
    {

        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos");
            return null;
        }
        else
        {
            List<GameObject> _newList;
            PoolManagerDictionary.TryGetValue(_key, out _newList);
            //_newList.shuffleList();
            for (int i = 0; i < _newList.Count; i++)
            {
                if (!_newList[i].activeSelf)
                {
                    return _newList[i];
                }
            }
            // Debug.Log("Nenhum Objeto encontrado dentro da lista da key: " + _key);
            return null;
        }
    }

    /// <summary>
    /// Responsável por retornar um objeto que está disponivel para ser usado dentro da lista de objeto
    /// </summary>
    /// <param name="_key"> Referência na qual a lista está armazenando os objetos que podem estar disponiveis </param>
    /// <returns></returns>
    public GameObject GetObjectDictionaryToCreate(string _key, GameObject _obj)
    {

        if (PoolManagerDictionary.ContainsKey(_key))
        {
            List<GameObject> _newList;
            PoolManagerDictionary.TryGetValue(_key, out _newList);
            //_newList.shuffleList();
            for (int i = 0; i < _newList.Count; i++)
            {
                if (!_newList[i].activeSelf)
                {
                    return _newList[i];
                }
            }
        }

        return add(_key, _obj);
    }

    /// <summary>
    /// Responsável por desabilitar todos os objetos da lista que é comparado com a chave
    /// </summary>
    /// <param name="_key"></param>
    public void DisableList(string _key)
    {
        if (!PoolManagerDictionary.ContainsKey(_key))
        {
            //Debug.Log("Não existe Esta chave :" + _key + " No gerenciador de Objetos");
        }
        else
        {
            List<GameObject> _newList;
            PoolManagerDictionary.TryGetValue(_key, out _newList);
            for (int i = 0; i < _newList.Count; i++)
            {
                _newList[i].SetActive(false);
            }
        }
    }
}