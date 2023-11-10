using System;
using System.Collections;
using System.Collections.Generic;

public class Graph<T>
{
    Dictionary<T, List<T>> vertices = new Dictionary<T, List<T>>();

    public void AddVertex(T data){
        vertices.Add(data, new List<T>());
    }

    //add a directed edge
    public bool AddEdge(T from, T to){
        //check if both vertices exist
        if(!vertices.ContainsKey(from) || !vertices.ContainsKey(to) ){
            return false;
        }

        //check if the list of connected vertices for "from" does not already contain "to"
        if(vertices[from].Contains(to)){
            return false;
        }

        //if not, add "to" to the list of connected vertices of "from"
        vertices[from].Add(to);
        return true;
    }

    public List<T> GetConnectedVertices(T data){
        if(vertices.ContainsKey(data)){
            return vertices[data];
        }

        return new List<T>();
    }

    public bool RemoveVertex(T data){
        if(!vertices.ContainsKey(data)){
            return false;
        }

        vertices.Remove(data);

        foreach(KeyValuePair<T, List<T>> pair in vertices)
        {
            if(pair.Value.Contains(data)){
                pair.Value.Remove(data);
            }
        }

        return true;
    }

    public bool ContainsVertex(T data){
        return vertices.ContainsKey(data);
    }

}