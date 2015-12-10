// ------------------------------------------------------------------------------
//  _______   _____ ___ ___   _   ___ ___ 
// |_   _\ \ / / _ \ __/ __| /_\ | __| __|
//   | |  \ V /|  _/ _|\__ \/ _ \| _|| _| 
//   |_|   |_| |_| |___|___/_/ \_\_| |___|
// 
// This file has been generated automatically by TypeSafe.
// Any changes to this file may be lost when it is regenerated.
// https://www.stompyrobot.uk/tools/typesafe
// 
// TypeSafe Version: 1.2.1-Unity5
// 
// ------------------------------------------------------------------------------



public sealed class SRLayers {
    
    private SRLayers() {
    }
    
    private const string _tsInternal = "1.2.1-Unity5";
    
    public static global::TypeSafe.Layer Default {
        get {
            return __all[0];
        }
    }
    
    public static global::TypeSafe.Layer TransparentFX {
        get {
            return __all[1];
        }
    }
    
    public static global::TypeSafe.Layer Ignore_Raycast {
        get {
            return __all[2];
        }
    }
    
    public static global::TypeSafe.Layer Water {
        get {
            return __all[3];
        }
    }
    
    public static global::TypeSafe.Layer UI {
        get {
            return __all[4];
        }
    }
    
    public static global::TypeSafe.Layer Obstacle {
        get {
            return __all[5];
        }
    }
    
    public static global::TypeSafe.Layer Enemy {
        get {
            return __all[6];
        }
    }
    
    public static global::TypeSafe.Layer Player {
        get {
            return __all[7];
        }
    }
    
    public static global::TypeSafe.Layer Item {
        get {
            return __all[8];
        }
    }
    
    public static global::TypeSafe.Layer Entity_Collider {
        get {
            return __all[9];
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.Layer> __all = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.Layer>(new global::TypeSafe.Layer[] {
                new global::TypeSafe.Layer("Default", 0),
                new global::TypeSafe.Layer("TransparentFX", 1),
                new global::TypeSafe.Layer("Ignore Raycast", 2),
                new global::TypeSafe.Layer("Water", 4),
                new global::TypeSafe.Layer("UI", 5),
                new global::TypeSafe.Layer("Obstacle", 8),
                new global::TypeSafe.Layer("Enemy", 9),
                new global::TypeSafe.Layer("Player", 10),
                new global::TypeSafe.Layer("Item", 11),
                new global::TypeSafe.Layer("Entity Collider", 12)});
    
    public static global::System.Collections.Generic.IList<global::TypeSafe.Layer> All {
        get {
            return __all;
        }
    }
}